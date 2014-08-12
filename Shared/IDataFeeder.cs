using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IDataFeeder
    {
        string SystemType { get; }
        List<RadioConfigData> GetRadioConfigDataList(string controllerId);
    }
}
