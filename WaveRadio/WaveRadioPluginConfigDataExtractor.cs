using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Xml.Linq;
using Shared;

namespace WaveRadio
{
    [Export(typeof(IRadioPluginConfigDataExtractor))]
    public class WaveRadioPluginConfigDataExtractor : IRadioPluginConfigDataExtractor
    {
        // This should be instantiated via dependency injection.  I initiate it here for simplicity.
        private readonly ISerializer _serializer = new Serializer();
        public string RadioType
        {
            get { return "wave"; }
        }

        public XElement ExtractConfigData(object configData)
        {
            var waveRadioConfig = configData as WaveRadioPluginConfig;
            Debug.Assert(waveRadioConfig != null);
            var toBeReturned = _serializer.Serialize(waveRadioConfig);
            return toBeReturned;
        }
    }
}