using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Shared
{
    public class Serializer : ISerializer
    {
        public T Deserialize<T>(XElement xElement) where T : class
        {
            if (xElement == null)
            {
                throw new ArgumentNullException("xElement","The xElement argument cannot be null");
            }

            T toBeReturnedObject;
            var serializer = new XmlSerializer(typeof (T));
            try
            {
                using (var reader = xElement.CreateReader())
                {
                    toBeReturnedObject = (T) serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                toBeReturnedObject = null;
            }

            return toBeReturnedObject;
        }


        public XElement Serialize<T>(T obj) where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj", "The obj argument cannot be null");
            }

            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                var xmlSerializer = new XmlSerializer(typeof (T));
                var ns = new XmlSerializerNamespaces();
                ns.Add("","");
                xmlSerializer.Serialize(streamWriter, obj, ns);
                memoryStream.Position = 0;
                return XDocument.Load(memoryStream).Root;
            }
        }
    }
}