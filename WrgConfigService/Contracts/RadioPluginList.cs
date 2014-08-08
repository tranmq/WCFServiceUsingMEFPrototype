using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WrgConfigService.Contracts
{
    [CollectionDataContract(Name = "Plugins", Namespace = "")]
    public class RadioPluginList : List<RadioPlugin>
    {
    }
}