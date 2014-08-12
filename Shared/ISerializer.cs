using System.Xml.Linq;

namespace Shared
{
    public interface ISerializer
    {
        T Deserialize<T>(XElement xElement) where T : class;
        XElement Serialize<T>(T obj) where T : class;
    }
}