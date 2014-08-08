using System.Runtime.Serialization;

namespace WrgConfigService.Contracts
{
    [DataContract(Namespace = "")]
    public class ControllerConfiguration
    {
        [DataMember(Name = "Plugins")]
        public RadioPluginList RadioPlugins;
    }
}