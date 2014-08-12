using System.Xml.Serialization;

namespace WaveRadio
{
    public class WaveSettings
    {
        [XmlAttribute("CCVersion")]
        public string CcVersion { get; set; }

        [XmlAttribute("CodecDescription")]
        public string CodecDescription { get; set; }

        [XmlAttribute("WTCRootUser")]
        public string WtcRootUser { get; set; }

        [XmlAttribute("ChannelBaseAddress")]
        public string ChannelBaseAddress { get; set; }

        // And so on
    }
}