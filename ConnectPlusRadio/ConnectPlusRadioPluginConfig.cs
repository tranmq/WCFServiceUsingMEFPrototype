using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConnectPlusRadio
{
    [Serializable]
    [XmlRoot("ConnectPlusRadioPlugin", Namespace = "", IsNullable = false)]
    public class ConnectPlusRadioPluginConfig
    {
        [XmlAttribute]
        public string Version { get; set; }

        [XmlElement("Settings")]
        public ConnectPlusSettings Settings { get; set; }

        [XmlArray("RadioSystems")]
        [XmlArrayItem("RadioSystem")]
        public List<ConnectPlusRadioSystem> RadioSystems { get; set; }

        [XmlArray("TalkGroups")]
        [XmlArrayItem("TalkGroup")]
        public List<ConnectPlusTalkGroup> TalkGroups { get; set; }
    }
}