using System.Xml.Serialization;

namespace ConnectPlusRadio
{
    public class ConnectPlusTalkGroup
    {
        [XmlAttribute("Cid")]
        public string Cid { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string TalkGroupId { get; set; }
    }
}