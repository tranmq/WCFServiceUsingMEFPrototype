using System.Collections.Generic;
using System.ComponentModel.Composition;
using ConnectPlusRadio;
using Shared;

namespace MtagConnectPlusRadioPluginConfigDataFeeder
{
    [Export("mtag", typeof (IRadioConfigFeeder))]
    public class RadioDataFeeder : IRadioConfigFeeder
    {
        public string RadioType
        {
            get
            {
                return "connect+";
            }
        }

        public RadioPluginData GetRadioConfigData()
        {
            var toBeReturned = new RadioPluginData
                               {
                                   RadioType = "connect+",
                                   Name = "ConnectPlusRadioPlugin",
                                   ConfigData = new ConnectPlusRadioPluginConfig
                                                {
                                                    Version = "1",
                                                    Settings = new ConnectPlusSettings
                                                               {
                                                                   MaxConcurrentTalkPaths = "100",
                                                                   TalkPathPortMin = "7000",
                                                                   TalkPathPortMax = "7999"
                                                               },
                                                    RadioSystems = new List<ConnectPlusRadioSystem>
                                                                   {
                                                                       new ConnectPlusRadioSystem
                                                                       {
                                                                           Id = "1",
                                                                           Name = "MTAG Connect Plus system 1",
                                                                           Type = "ConnectPlus"
                                                                       },
                                                                       new ConnectPlusRadioSystem
                                                                       {
                                                                           Id = "2",
                                                                           Name = "MTAG Connect Plus system 2",
                                                                           Type = "ConnectPlus"
                                                                       }
                                                                   },
                                                    TalkGroups = new List<ConnectPlusTalkGroup>
                                                                 {
                                                                     new ConnectPlusTalkGroup
                                                                     {
                                                                         Cid = "1",
                                                                         Name = "MTAG Talkgroup 1",
                                                                         TalkGroupId = "8001"
                                                                     },
                                                                     new ConnectPlusTalkGroup
                                                                     {
                                                                         Cid = "2",
                                                                         Name = "MTAG Talkgroup 2",
                                                                         TalkGroupId = "8002"
                                                                     },
                                                                     new ConnectPlusTalkGroup
                                                                     {
                                                                         Cid = "3",
                                                                         Name = "MTAG Talkgroup 3",
                                                                         TalkGroupId = "8003"
                                                                     }
                                                                 }
                                                }
                               };

            return toBeReturned;
        }
    }
}