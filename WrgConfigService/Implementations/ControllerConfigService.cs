using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using Shared;
using WrgConfigService.Contracts;

namespace WrgConfigService.Implementations
{
    [Export]
    [Export(typeof(IControllerConfigService))]
    public class ControllerConfigService : IControllerConfigService
    {
        private readonly IEnumerable<IDataFeeder> _dataFeeders;

        [ImportingConstructor]
        public ControllerConfigService([ImportMany] IEnumerable<IDataFeeder> dataFeeders)
        {
            _dataFeeders = dataFeeders;
        }

        public ControllerConfiguration GetControllerConfig(string controllerId)
        {
            var controllerConfiguration = new ControllerConfiguration
            {
                RadioPlugins = new RadioPluginList()
            };

            var dataFeeder = _dataFeeders.Single(x => x.SystemType == ConfigurationManager.AppSettings["SystemType"]);
            var radioConfigDataList = dataFeeder.GetRadioConfigDataList(controllerId);



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