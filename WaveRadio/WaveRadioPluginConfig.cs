using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WaveRadio
{
    [Serializable]
    [XmlRoot("WAVE", Namespace = "", IsNullable = false)]
    public class WaveRadioPluginConfig
    {
        [XmlElement("Settings")]
        public WaveSettings WaveSettings { get; set; }

        [XmlArray("Profiles")]
        [XmlArrayItem("Profile")]
        public List<WaveProfile> WaveProfileList { get; set; }

        [XmlArray("Zones")]
        [XmlArrayItem("Zone")]
        public List<WaveZone> WaveZoneList { get; set; }
    }
}
