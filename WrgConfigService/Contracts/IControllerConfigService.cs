using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WrgConfigService.Contracts
{
    [ServiceContract]
    public interface IControllerConfigService
    {
        [WebGet(UriTemplate = "/ControllerConfig/{controllerId}")]
        ControllerConfiguration GetControllerConfig(string controllerId);
    }
}