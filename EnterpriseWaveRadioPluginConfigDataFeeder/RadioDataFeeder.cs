using System.Collections.Generic;
using System.ComponentModel.Composition;
using Shared;
using WaveRadio;

namespace EnterpriseWaveRadioPluginConfigDataFeeder
{
    [Export("enterprise", typeof (IRadioConfigFeeder))]
    public class RadioDataFeeder : IRadioConfigFeeder
    {
        public string RadioType
        {
            get
            {
                return "wave";
            }
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
                                                                       CodecDescription = "SpecialCodecForEnterprise",
                                                                       ChannelBaseAddress = "192.168.42.42",
                                                                       WtcRootUser = "EnterpriseRoot"
                                                                   },
                                                    WaveProfileList = new List<WaveProfile>
                                                                      {
                                                                          new WaveProfile
                                                                          {
                                                                              AccessLevel = "1",
                                                                              Description = "The Enterprise profile",
                                                                              Name = "Enterprise Profile"
                                                                          }
                                                                      },
                                                    WaveZoneList = new List<WaveZone>
                                                                   {
                                                                       new WaveZone
                                                                       {
                                                                           Name = "Enterprise zone",
                                                                           Description = "Enterprise default zone",
                                                                           Id = "{3310fd2d-a985-1234-a30e-063611de75bd}"
                                                                       }
                                                                   }
                                                }
                               };

            return toBeReturned;
        }
    }
}