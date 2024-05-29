using Aveva.ApplicationFramework;
using Aveva.ApplicationFramework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3DAddIn_6
{
    public class MyAddIn : IAddin
    {
        public string Name
        {
            get { return "MyAddin"; }
        }

        public string Description
        {
            get { return "My Test Addin"; }
        }

        public void Start(ServiceManager serviceManager)
        {
            CommandManager commandManager = (CommandManager)serviceManager.GetService(typeof(CommandManager));
            WindowManager windowManager = (WindowManager)serviceManager.GetService(typeof(WindowManager));

            TextBoxCmd textBoxCmd = new TextBoxCmd();
            ComboBoxCmd comboBoxCmd = new ComboBoxCmd();

            OperationCmd operationCmd = new OperationCmd(textBoxCmd, comboBoxCmd);

            commandManager.Commands.Add(textBoxCmd);
            commandManager.Commands.Add(comboBoxCmd);
            commandManager.Commands.Add(operationCmd);

            OperationOnArgs operationOnArgs = new OperationOnArgs(commandManager);
            operationOnArgs.performOperations();
        }

        public void Stop()
        {
            
        }
    }
}
