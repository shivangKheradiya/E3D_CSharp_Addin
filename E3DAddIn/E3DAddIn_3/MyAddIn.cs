using Aveva.ApplicationFramework;
using Aveva.ApplicationFramework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3DAddIn_3
{
    public class MyAddIn : IAddinInjected
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

        }

        public void Start(IDependencyResolver resolver)
        {
            WindowManager E3DWindowManager = (WindowManager)resolver.GetImplementationOf<IWindowManager>();
            DockingWindowCmd dwCmd = new DockingWindowCmd(E3DWindowManager);
            MdiWindowCmd mdiCmd = new MdiWindowCmd(E3DWindowManager);
            CommandManager E3DCommandManager = (CommandManager)resolver.GetImplementationOf<ICommandManager>();
            E3DCommandManager.Commands.Add(dwCmd);
            E3DCommandManager.Commands.Add(mdiCmd);
        }

        public void Stop()
        {

        }

    }
}
