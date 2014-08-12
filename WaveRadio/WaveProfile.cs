using System;
using System.Xml.Serialization;

namespace WaveRadio
{
    [Serializable]
    [XmlRoot("Profile")]
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