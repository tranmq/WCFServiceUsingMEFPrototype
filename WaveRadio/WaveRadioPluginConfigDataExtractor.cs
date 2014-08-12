using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Xml.Linq;
using Shared;

namespace WaveRadio
{
    [Export(typeof(IRadioPluginConfigDataExtractor))]
    public class WaveRadioPluginConfigDataExtractor : IRadioPluginConfigDataExtractor
    {
        public string RadioType
        {
            get { return "wave"; }
        }

        public XElement ExtractConfigData(object configData)
        {
            var waveRadioConfig = configData as WaveRadioPluginConfig;
            Debug.Assert(waveRadioConfig != null);

            return null;
        }
    }
}