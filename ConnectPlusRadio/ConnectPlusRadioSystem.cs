using System.Xml.Serialization;

namespace ConnectPlusRadio
{
    public class ConnectPlusRadioSystem
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Type { get; set; }
    }
}