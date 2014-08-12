namespace Shared
{
    public class RadioConfigData
    {
        public string RadioType { get; set; } // C+, CP, LCP

        public string Name { get; set; } // WAVERadioPlugin, ConnectPlusRadioPlugin

        public object ConfigData { get; set; } // Each radio system has a totally different configuration.  Hence object.
    }
}