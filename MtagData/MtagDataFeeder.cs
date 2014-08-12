using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Shared;

namespace MtagData
{
    [Export(typeof (IDataFeeder))]
    public class MtagDataFeeder : IDataFeeder
    {
        // In real case, this is populated from a data source.
        private static readonly List<string> SupportedRadios = new List<string> {"wave", "connect+"};

        public string SystemType
        {
            get { return "mtag"; }
        }

        public List<RadioConfigData> GetRadioConfigDataList(string controllerId)
        {
            // controller ID is ignored in MTAG.
            var toBeReturned = SupportedRadios.Select(radio => new RadioConfigData { RadioType = radio, ConfigData = DateTime.Now }).ToList();
            return toBeReturned;
        }
    }
}