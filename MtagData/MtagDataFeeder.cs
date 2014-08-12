using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Shared;

namespace MtagData
{
    [Export(typeof (IDataFeeder))]
    public class MtagDataFeeder : IDataFeeder
    {
        // In real case, this is populated from a data source.
        private static readonly List<string> SupportedRadios = new List<string> {"wave", "connect+"};

        private readonly IEnumerable<IRadioConfigFeeder> _radioConfigFeeders;

        [ImportingConstructor]
        public MtagDataFeeder([ImportMany("mtag", typeof(IRadioConfigFeeder))] IEnumerable<IRadioConfigFeeder> radioConfigFeeders)
        {
            _radioConfigFeeders = radioConfigFeeders;
        }

        public string SystemType
        {
            get { return "mtag"; }
        }

        public List<RadioPluginData> GetRadioConfigDataList(string controllerId)
        {
            // controller ID is ignored in MTAG.
            var toBeReturned = new List<RadioPluginData>();

            foreach (var radio in SupportedRadios)
            {
                if (_radioConfigFeeders.All(x => x.RadioType != radio))
                {
                    continue;;
                }
                var correspondingConfigFeeder = _radioConfigFeeders.Single(x => x.RadioType == radio);
                var radioPluginData = correspondingConfigFeeder.GetRadioConfigData();
                toBeReturned.Add(radioPluginData);
            }

            return toBeReturned;
        }
    }
}