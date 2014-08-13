using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Xml.Linq;
using Shared;

namespace ConnectPlusRadio
{
    [Export(typeof(IRadioPluginConfigDataExtractor))]
    public class ConnectPlusRadioPluginConfigDataExtractor : IRadioPluginConfigDataExtractor
    {
        // This should be instantiated via dependency injection.  I initiate it here for simplicity.
        private readonly ISerializer _serializer = new Serializer();

        public string RadioType
        {
            get
            {
                return "connect+";
            }
        }

        public XElement ExtractConfigData(object configData)
        {
            var connectPlusRadioConfig = configData as ConnectPlusRadioPluginConfig;
            Debug.Assert(connectPlusRadioConfig != null);
            var toBeReturned = _serializer.Serialize(connectPlusRadioConfig);
            return toBeReturned;
        }
    }
}