using Aveva.ApplicationFramework;
using Aveva.ApplicationFramework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3DAddIn_7
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
            CommandManager commandManager = (CommandManager)DependencyResolver.GetImplementationOf<ICommandManager>();

            TextBoxCmd textBoxCmd = new TextBoxCmd();
            ExceptionCmd exceptionCmd = new ExceptionCmd(textBoxCmd);

            commandManager.Commands.Add(textBoxCmd);
            commandManager.Commands.Add(exceptionCmd);
        }

        public void Stop()
        {
            
        }
    }
}
