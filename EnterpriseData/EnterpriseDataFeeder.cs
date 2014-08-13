using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Shared;

namespace EnterpriseData
{
    [Export(typeof (IDataFeeder))]
    public class EnterpriseDataFeeder : IDataFeeder
    {
        // In real case, this is populated from a data source.
        private static readonly Dictionary<string, List<string>> SupportedRadioSystemsByController =
            new Dictionary<string, List<string>>
            {
                {"1", new List<string>{"wave", "connect+"}},
                {"2", new List<string>{"wave", "cp"}}
            };
        private readonly IEnumerable<IRadioConfigFeeder> _radioConfigFeeders;

        [ImportingConstructor]
        public EnterpriseDataFeeder([ImportMany("enterprise", typeof (IRadioConfigFeeder))] IEnumerable<IRadioConfigFeeder> radioConfigFeeders)
        {
            _radioConfigFeeders = radioConfigFeeders;
        }

        public string SystemType
        {
            get
            {
                return "enterprise";
            }
        }

        public List<RadioPluginData> GetRadioConfigDataList(string controllerId)
        {
            if (!SupportedRadioSystemsByController.ContainsKey(controllerId))
            {
                return new List<RadioPluginData>();
            }

            var toBeReturned = new List<RadioPluginData>();
            var supportedRadioSystems = SupportedRadioSystemsByController[controllerId];
            foreach (var radio in supportedRadioSystems)
            {
                if (_radioConfigFeeders.All(x => x.RadioType != radio))
                {
                    continue;
                }
                var correspondingConfigFeeder = _radioConfigFeeders.Single(x => x.RadioType == radio);
                var radioPluginData = correspondingConfigFeeder.GetRadioConfigData();
                toBeReturned.Add(radioPluginData);
            }

            return toBeReturned;
        }
    }
}