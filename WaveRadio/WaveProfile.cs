using System.Xml.Serialization;

namespace WaveRadio
{
    public class WaveProfile
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("AccessLevel")]
        public string AccessLevel { get; set; }

        [XmlAttribute("Description")]
        public string Description { get; set; }
    }
}