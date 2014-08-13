using System.Collections.Generic;

namespace Shared
{
    public interface IDataFeeder
    {
        string SystemType { get; }
        List<RadioPluginData> GetRadioConfigDataList(string controllerId);
    }
}
