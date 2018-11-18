using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerewolfClient
{
    public class WerewolfCommand : Command
    {
        public new enum CommandEnum
        {
            SignUp = 1,
            SignIn = 2,
            SignOut = 3,
            JoinGame = 4,
            RequestUpdate = 5,
            LeaveGame = 6,
            Vote = 7,
            Action = 8,
            Chat = 9,
        };
        public new CommandEnum Action { get; set; }
    }
    class WerewolfController : Controller
    {
        private static WerewolfController _instance = null;

        public static WerewolfController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WerewolfController();
            }
            return _instance;
        }
        private WerewolfController()
        {

        }
        public override void ActionPerformed(Command cmd)
        {
            foreach(Model m in mList)
            {
                if (m is WerewolfModel && cmd is WerewolfCommand)
                {
                    WerewolfCommand wcmd = (WerewolfCommand)cmd;
                    WerewolfModel wm = (WerewolfModel)m;
                    switch (wcmd.Action)
                    {
                        case WerewolfCommand.CommandEnum.SignUp:
                            wm.SignUp(cmd.Payloads["Server"], cmd.Payloads["Login"], cmd.Payloads["Password"]);
                            break;

                        case WerewolfCommand.CommandEnum.SignIn:
                            wm.SignIn(cmd.Payloads["Server"], cmd.Payloads["Login"], cmd.Payloads["Password"]);
                            break;

                        case WerewolfCommand.CommandEnum.SignOut:
                            break;

                        case WerewolfCommand.CommandEnum.JoinGame:
                            wm.JoinGame();
                            break;

                        case WerewolfCommand.CommandEnum.RequestUpdate:
                            wm.Update();
                            break;
                        case WerewolfCommand.CommandEnum.Vote:
                            wm.Vote(cmd.Payloads["Target"]);
                            break;
                        case WerewolfCommand.CommandEnum.Action:
                            wm.Action(cmd.Payloads["Target"]);
                            break;
                        case WerewolfCommand.CommandEnum.Chat:
                            wm.Chat(cmd.Payloads["Message"]);
                            break;
                    }
                }
            }
        }
    }
}
