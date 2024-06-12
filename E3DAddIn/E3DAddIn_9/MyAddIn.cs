using Aveva.ApplicationFramework;
using Aveva.ApplicationFramework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3DAddIn_9
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

            FilterElementsCmd filterElementsCmd = new FilterElementsCmd();

            commandManager.Commands.Add(filterElementsCmd);
        }

        public void Stop()
        {
            
        }
    }
}
