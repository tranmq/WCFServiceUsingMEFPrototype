namespace Shared
{
    public class RadioPluginData
    {
        /// <summary>
        /// The type of the radio system this config data is for.
        /// E.g.: wave or C+ or CP or LCP
        /// </summary>
        public string RadioType { get; set; }

        /// <summary>
        /// The name of the plugin that the Controller needs to load to work with the Radio System.
        /// E.g.: WAVERadioPlugin, ConnectPlusRadioPlugin
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Each radio system has a totally different configuration.  Hence object.
        /// The concrete RadioConfigFeeder needs to instantiate an instance of the data object that both the feeder and
        /// the extractor understand.
        /// </summary>
        public object ConfigData { get; set; }
    }
}