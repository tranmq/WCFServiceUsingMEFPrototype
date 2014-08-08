using System.Runtime.Serialization;
using System.Xml.Linq;

namespace WrgConfigService.Contracts
{
    [DataContract(Name = "Plugin", Namespace = "")]
    public class RadioPlugin
    {
        [DataMember(Name = "Name", Order = 1)]
        public string PluginName;

        [DataMember(Name = "Config", Order = 1)]
        public XElement RadioConfig;
    }
}