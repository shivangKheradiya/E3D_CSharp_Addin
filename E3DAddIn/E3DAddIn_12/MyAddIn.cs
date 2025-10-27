using Aveva.ApplicationFramework;
using Aveva.Core.Utilities.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using swf = System.Windows.Forms;

namespace E3DAddIn_12
{
    public class MyAddIn : IAddin
    {
        int formsCount;
        swf.Timer timer;

        Assembly DruidNetAssembly;
        Type DruidPMLFormType;

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
            string dllFilePath = @"C:\Program Files (x86)\AVEVA\Everything3D2.10\DruidNet.dll"; 
            DruidNetAssembly = Assembly.LoadFile(dllFilePath);
            string typeName = "Aveva.Core.Presentation.Druid.UI_DruidForm";
            DruidPMLFormType = DruidNetAssembly.GetType(typeName);

            formsCount = swf.Application.OpenForms.Count;
            timer = new swf.Timer();

            timer.Tick += Timer_Tick;

            timer.Interval = 10000;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int formsCount = swf.Application.OpenForms.Count;

            Command.CreateCommand(string.Format(@"$P Form Count : {0}", formsCount)).RunInPdms();
            if (formsCount != 0)
            {
                timer.Stop();

                Command.CreateCommand(@"$P ------------------------").RunInPdms();
                foreach (Form fm in swf.Application.OpenForms)
                {
                    Type type = fm.GetType();

                    if (type == DruidPMLFormType)
                    {
                        Command.CreateCommand(string.Format(@"$P {0} Form is opened.", fm.Text)).RunInPdms();
                        fm.Move += Fm_Move;
                    }
                }
            }
            timer.Enabled = true;
        }

        private void Fm_Move(object sender, EventArgs e)
        {
            Command.CreateCommand("$p Form Is Moving...").RunInPdms();
        }

        public void Stop()
        {
        }
    }
}
