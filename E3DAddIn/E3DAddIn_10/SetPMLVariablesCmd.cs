using Aveva.ApplicationFramework.Presentation;
using ac = Aveva.Core.Utilities.CommandLine;

namespace E3DAddIn_10
{
    public class SetPMLVariablesCmd : Command
    {
        public SetPMLVariablesCmd() 
        {
            base.Key = "E3DAddIn_10.SetPMLVariablesCmd";
        }

        public override void Execute() 
        {
            try
            {
                string cmdText = "$P Set Variable Method Started \n" +
                                 "!!varString = |MyName| \n" +
                                 "!!varBool   = true \n" +
                                 "!!varReal   = 5 \n" ;

                ac.Command command = ac.Command.CreateCommand(cmdText);
                if (command.RunInPdms()) 
                {
                    ac.Command okCommand = ac.Command.CreateCommand("$P variables are set");
                    okCommand.RunInPdms();
                }
            }
            catch (System.Exception)
            {
            }
        }
    }
}