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
        [PluginEntryPoint("Welcome", "1.2.0", "Test.", "Tino")]
        void Enabled()
        {
            EventManager.RegisterEvents(this);
        }

          [PluginEvent(ServerEventType.PlayerJoined)]
          void OnPlayerJoin(Player player)
         {
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
