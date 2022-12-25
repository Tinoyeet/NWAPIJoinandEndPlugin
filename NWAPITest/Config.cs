using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAPITestPlugin
{
    public class Config
    {

        [Description("The Welcome message. You can also use colour codes!")]
        public string Welcome { get; set; } = "Welcome back %playername%! Don't forget to join our Discord Server.";

        [Description("The Round End message.")]
        public string RoundEnd { get; set; } = "Good Job %playername%!";

        [Description("The Duration of the Join message.")]
        public ushort Duration { get; set; } = 5;

        [Description("The Duration of the Game End message.")]
        public ushort Duration2 { get; set; } = 5;

        [Description("If it should use a Broadcast or Hint. true = Broadcast, false = Hint!")]
        public bool WelcomeType { get; set; } = true;
    }
}
