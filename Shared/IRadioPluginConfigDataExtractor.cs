using System.Xml.Linq;

namespace Shared
{
    public interface IRadioPluginConfigDataExtractor
    {
        string RadioType { get; }

        XElement ExtractConfigData(object configData);
    }
}