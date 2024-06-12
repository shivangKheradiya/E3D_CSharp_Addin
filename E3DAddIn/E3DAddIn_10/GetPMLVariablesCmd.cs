using Aveva.ApplicationFramework.Presentation;
using ac = Aveva.Core.Utilities.CommandLine;

namespace E3DAddIn_10
{
    public class GetPMLVariablesCmd : Command
    {
        public GetPMLVariablesCmd() 
        {
            base.Key = "E3DAddIn_10.GetPMLVariablesCmd";
        }

        public override void Execute() 
        {
            try
            {
                ac.Command getCommand = ac.Command.CreateCommand("");

                // Converting to Upper Case is necessory
                string varString    = getCommand.GetPMLVariableString("varString".ToUpper());
                bool varBool        = getCommand.GetPMLVariableBoolean("varBool".ToUpper());
                double varReal      = getCommand.GetPMLVariableReal("varReal".ToUpper());

                string outputText = "$P varString, varBool, varReal : " + varString + ", " + varBool.ToString() + "," + varReal.ToString() ;
                
                ac.Command outputCmd = ac.Command.CreateCommand(outputText);
                outputCmd.RunInPdms();
            }
            catch (System.Exception)
            {
            }
        }
    }
}