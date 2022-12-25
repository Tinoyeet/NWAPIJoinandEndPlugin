using PluginAPI.Core.Attributes;
using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAPITestPlugin
{
    public class Plugin
    {
        [PluginEntryPoint("Welcome", "1.3.1", "It will send a Message to each Player when the player connects and when the Round ends.", "Tino")]
        void Enabled()
        {
            EventManager.RegisterEvents(this);
        }

        [PluginEvent(ServerEventType.PlayerJoined)]
        void OnPlayerJoin(Player player)
        {
            if (Config.WelcomeType)
                    Broadcast.Singleton.TargetAddElement(player.ReferenceHub.characterClassManager.connectionToClient, Config.Welcome.Replace("%playername%", player.Nickname), Config.Duration, Broadcast.BroadcastFlags.Normal);
                else
                    player.ReceiveHint(Config.Welcome.Replace("%playername%", player.Nickname), Config.Duration);
        }

        [PluginEvent(ServerEventType.RoundEnd)]
        void OnRoundEnd(RoundSummary.LeadingTeam curLeadingTeam)
        {
            foreach (Player player in Server.GetPlayers())
            {
                Broadcast.Singleton.TargetAddElement(player.ReferenceHub.characterClassManager.connectionToClient, Config.RoundEnd.Replace("%playername%", player.Nickname), Config.Duration2, Broadcast.BroadcastFlags.Normal);
            }
        }

        [PluginConfig]
        public Config Config;
    }
}
