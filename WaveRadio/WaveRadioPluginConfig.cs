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

        [XmlElement("Profiles")]
        public WaveProfileList WaveProfileList { get; set; }

        [XmlElement("Zones")]
        public WaveZoneList WaveZoneList { get; set; }
    }

    [Serializable]
    public class WaveProfileList : List<WaveProfile>
    {
    }

    [Serializable]
    public class WaveZoneList : List<WaveZone>
    {
    }
}
