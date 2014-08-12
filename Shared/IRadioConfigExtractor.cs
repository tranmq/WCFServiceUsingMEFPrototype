using System.Xml.Linq;

namespace Shared
{
    public interface IRadioConfigExtractor
    {
        string RadioType { get; }

        XElement ExtractConfigData(object configData);
    }
}