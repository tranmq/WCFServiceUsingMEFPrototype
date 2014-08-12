using System.ComponentModel.Composition;
using Shared;
using WaveRadio;

namespace MtagWaveRadioPluginConfigDataFeeder
{
    [Export("mtag", typeof (IRadioConfigFeeder))]
    public class MtagWaveRadioPluginConfigDataFeeder : IRadioConfigFeeder
    {
        public string RadioType
        {
            get { return "wave"; }
        }

        public RadioPluginData GetRadioConfigData()
        {
            var toBeReturned = new RadioPluginData
            {
                RadioType = "wave",
                Name = "WAVERadioPlugin",
                ConfigData = new WaveRadioPluginConfig
                {
                    WaveSettings = new WaveSettings
                    {
                        CcVersion = "4",
                        CodecDescription = "SpecialCodecForMtag",
                        ChannelBaseAddress = "192.168.42.42",
                        WtcRootUser = "mtagRoot"
                    },
                    WaveProfileList = new WaveProfileList
                    {
                        new WaveProfile
                        {
                            AccessLevel = "1",
                            Description = "The MTAG profile",
                            Name = "MTAG Profile"
                        }
                    },
                    WaveZoneList = new WaveZoneList
                    {
                        new WaveZone
                        {
                            Name = "MTAG zone",
                            Description = "MTAG default zone",
                            Id = "{3310fd2d-a985-4264-a30e-063611de75bd}"
                        }
                    }
                }
            };

            return toBeReturned;
        }
    }
}