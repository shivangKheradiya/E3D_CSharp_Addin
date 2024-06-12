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
    public class FormCounter
    {
        public string FormName { get; set; }
        public int CounterForOpen { get; set; }
        public bool isAlive { get; set; }
    }

    public class MyAddIn : IAddin
    {
        int formsCount;
        swf.Timer timer;
        List<FormCounter> Counter = new List<FormCounter>();

        Assembly DruidNetAssembly;
        Type FormType;

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
            string dllFilePath = @"C:\Program Files (x86)\AVEVA\Everything3D3.1\DruidNet.dll"; 
            DruidNetAssembly = Assembly.LoadFile(dllFilePath);
            string typeName = "Aveva.Core.Presentation.Druid.UI_DruidForm";
            FormType = DruidNetAssembly.GetType(typeName);

            formsCount = swf.Application.OpenForms.Count;
            timer = new swf.Timer();

            timer.Tick += Timer_Tick;

            timer.Interval = 10000;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int formCounterNew = swf.Application.OpenForms.Count;

            if (formCounterNew != formsCount) 
            {
                timer.Stop();
                formsCount = formCounterNew;

                List<Form> openForms = new List<Form>();

                foreach (Form fm in swf.Application.OpenForms) 
                {
                    Type type = fm.GetType();

                    if(type == FormType)
                    {
                        openForms.Add(fm);
                    }
                }

                foreach (Form frm in openForms)
                {
                    if (!Counter.Exists(o => o.FormName == frm.Text))
                    {
                        Counter.Add(new FormCounter() { FormName = frm.Text, CounterForOpen = 1, isAlive = true});
                    }
                    else
                    {
                        FormCounter fmCounter = Counter.Find(o => o.FormName == frm.Text);
                        if (!fmCounter.isAlive)
                        {
                            fmCounter.CounterForOpen += 1;
                            fmCounter.isAlive = true;
                        }
                    }
                }
                
                foreach (FormCounter fmc in Counter)
                {
                    if (openForms.Exists(o => o.Text == fmc.FormName))
                    {
                        fmc.isAlive = false;
                    }
                }
            }

            Command.CreateCommand(@"$P ------------------------").RunInPdms();
            foreach (FormCounter logForm in Counter)
            {
                Command.CreateCommand(string.Format(@"$P {0} Form is open {1} times.", logForm.FormName, logForm.CounterForOpen)).RunInPdms();
            }

            timer.Enabled = true;
        }

        public void Stop()
        {
        }
    }
}
