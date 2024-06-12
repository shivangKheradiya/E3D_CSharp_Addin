using Aveva.ApplicationFramework;
using Aveva.ApplicationFramework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3DAddIn_10
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
            commandManager.Commands.Add(new SetPMLVariablesCmd());
            commandManager.Commands.Add(new GetPMLVariablesCmd());
        }

        public void Stop()
        {
        }
    }
}
