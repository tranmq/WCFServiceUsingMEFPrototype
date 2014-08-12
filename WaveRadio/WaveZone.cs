using System;
using System.Xml.Serialization;

namespace WaveRadio
{
    [Serializable]
    [XmlRoot("Zone")]
    public class WaveZone
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlAttribute("Description")]
        public string Description { get; set; }
    }
}