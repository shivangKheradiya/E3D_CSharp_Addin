using Aveva.ApplicationFramework;
using Aveva.ApplicationFramework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3DAddIn_2
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
            // For old Versions
            //WindowManager E3DWindowManager = (WindowManager)serviceManager.GetService(typeof(WindowManager));

            // Fore new Versions
            WindowManager E3DWindowManager = (WindowManager)DependencyResolver.GetImplementationOf<IWindowManager>();
            CommandManager E3DCommandManager = (CommandManager)DependencyResolver.GetImplementationOf<ICommandManager>();

            DockingWindowCmd dwCmd = new DockingWindowCmd(E3DWindowManager);
            E3DCommandManager.Commands.Add(dwCmd);
        }

        public void Stop()
        {

        }

    }
}
