using Aveva.ApplicationFramework;
using Aveva.ApplicationFramework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3DAddIn_8
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
            WindowManager windowManager = (WindowManager)DependencyResolver.GetImplementationOf<IWindowManager>();
            CommandManager commandManager = (CommandManager)DependencyResolver.GetImplementationOf<ICommandManager>();

            GridCmd gridCmd = new GridCmd(windowManager);

            commandManager.Commands.Add(gridCmd);
        }

        public void Stop()
        {
            
        }
    }
}
