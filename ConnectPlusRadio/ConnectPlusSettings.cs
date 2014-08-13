using System.Xml.Serialization;

namespace ConnectPlusRadio
{
    public class ConnectPlusSettings
    {
        [XmlElement]
        public string TalkPathPortMin { get; set; }

        [XmlElement]
        public string TalkPathPortMax { get; set; }

        [XmlElement]
        public string MaxConcurrentTalkPaths { get; set; }
    }
}