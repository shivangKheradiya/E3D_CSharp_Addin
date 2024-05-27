using Aveva.ApplicationFramework;
using Aveva.ApplicationFramework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3DAddIn_4
{
    public class MyAddIn : IAddin
    {
        public string Name{
            get { return "MyAddin"; }
        }

        public string Description
        {
            get { return "My Test Addin"; }
        }

        public void Start(ServiceManager serviceManager)
        {
            WindowManager E3DWindowManager = (WindowManager)serviceManager.GetService(typeof(WindowManager));
            CommandManager E3DCommandManager = (CommandManager)serviceManager.GetService(typeof(CommandManager));

            MdiWpfWindowCmd mdiWpfWindowCmd = new MdiWpfWindowCmd(E3DWindowManager);
            
            E3DCommandManager.Commands.Add(mdiWpfWindowCmd);
        }

        public void Stop()
        {

        }
    }
}
