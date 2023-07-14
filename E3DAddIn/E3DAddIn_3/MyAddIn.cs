﻿using Aveva.ApplicationFramework;
using Aveva.ApplicationFramework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3DAddIn_3
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
            WindowManager E3DWindowManager = (WindowManager)serviceManager.GetService(typeof(WindowManager));
            DockingWindowCmd dwCmd = new DockingWindowCmd(E3DWindowManager);
            MdiWindowCmd mdiCmd = new MdiWindowCmd(E3DWindowManager);
            CommandManager E3DCommandManager = (CommandManager)serviceManager.GetService(typeof(CommandManager));
            E3DCommandManager.Commands.Add(dwCmd);
            E3DCommandManager.Commands.Add(mdiCmd);
        }

        public void Stop()
        {

        }

    }
}
