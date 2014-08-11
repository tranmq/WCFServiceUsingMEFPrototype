using System.ComponentModel.Composition;
using System.Xml.Linq;
using WrgConfigService.Contracts;

namespace WrgConfigService.Implementations
{
    [Export]
    [Export(typeof(IControllerConfigService))]
    public class ControllerConfigService : IControllerConfigService
    {
        public ControllerConfiguration GetControllerConfig(string controllerId)
        {
            var controllerConfiguration = new ControllerConfiguration
            {
                RadioPlugins = new RadioPluginList()
            };

            var radioPlugin1 = new RadioPlugin
            {
                PluginName = "WAVERadioPlugin"
            };
            var radioPlugin1Config = XElement.Parse("<WAVE><Settings><Profiles><Profile Name='Default Profile' /></Profiles></Settings></WAVE>");
            radioPlugin1.RadioConfig = radioPlugin1Config;
            controllerConfiguration.RadioPlugins.Add(radioPlugin1);

            var radioPlugin2 = new RadioPlugin
            {
                PluginName = "ConnectPlusRadioPlugin"
            };
            var radioPlugin2Config = XElement.Parse("<ConnectPlusRadioPlugin Version='1'><Settings><TalkPathPortMin>7000</TalkPathPortMin></Settings></ConnectPlusRadioPlugin>");
            radioPlugin2.RadioConfig = radioPlugin2Config;
            controllerConfiguration.RadioPlugins.Add(radioPlugin2);

            return controllerConfiguration;
        }
    }
}