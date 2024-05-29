using Aveva.ApplicationFramework.Presentation;
using System;
using System.Windows.Forms;

namespace E3DAddIn_6
{
    public class OperationOnArgs
    {
        private CommandManager commandManager;

        public OperationOnArgs(CommandManager commandManager)
        {
            this.commandManager = commandManager;
        }

        public void performOperations()
        {
            Command operationCmd = this.commandManager.Commands["E3DAddIn_6.OperationCmd"];
            operationCmd.BeforeCommandExecute += OperationCmd_BeforeCommandExecute;
        }

        private void OperationCmd_BeforeCommandExecute(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Command tbCmd = this.commandManager.Commands["E3DAddIn_6.TextBoxCmd"];

                if (tbCmd.Value.ToString() == String.Empty)
                {
                    e.Cancel = true;
                    Aveva.Core.Utilities.CommandLine.Command.CreateCommand("$P Text Box is Empty. Operation Aborted.").RunInPdms();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("There is some error while executing OperationCmd_BeforeCommandExecute method");
            }

        }
    }
}