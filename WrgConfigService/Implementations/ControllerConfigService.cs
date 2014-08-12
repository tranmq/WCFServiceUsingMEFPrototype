using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using Shared;
using WrgConfigService.Contracts;

namespace WrgConfigService.Implementations
{
    [Export]
    [Export(typeof (IControllerConfigService))]
    public class ControllerConfigService : IControllerConfigService
    {
        private readonly IEnumerable<IRadioPluginConfigDataExtractor> _configDataExtractors;
        private readonly IEnumerable<IDataFeeder> _dataFeeders;

        [ImportingConstructor]
        public ControllerConfigService([ImportMany] IEnumerable<IDataFeeder> dataFeeders,
            [ImportMany] IEnumerable<IRadioPluginConfigDataExtractor> configDataExtractors)
        {
            _dataFeeders = dataFeeders;
            _configDataExtractors = configDataExtractors;
        }

        public ControllerConfiguration GetControllerConfig(string controllerId)
        {
            var controllerConfiguration = new ControllerConfiguration
            {
                RadioPlugins = new RadioPluginList()
            };

            IDataFeeder dataFeeder =
                _dataFeeders.Single(x => x.SystemType == ConfigurationManager.AppSettings["SystemType"]);
            List<RadioPluginData> radioConfigDataList = dataFeeder.GetRadioConfigDataList(controllerId);

            foreach (RadioPluginData radioPluginData in radioConfigDataList)
            {
                if (_configDataExtractors.All(x => x.RadioType != radioPluginData.RadioType))
                {
                    continue;
                }

                IRadioPluginConfigDataExtractor extractor =
                    _configDataExtractors.Single(x => x.RadioType == radioPluginData.RadioType);
                controllerConfiguration.RadioPlugins.Add(new RadioPlugin
                                                         {
                                                             PluginName = radioPluginData.Name,
                                                             RadioConfig = extractor.ExtractConfigData(radioPluginData.ConfigData)
                                                         });
            }

            return controllerConfiguration;
        }
    }
}