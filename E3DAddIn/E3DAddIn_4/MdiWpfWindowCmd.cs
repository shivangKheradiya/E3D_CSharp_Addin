using Aveva.ApplicationFramework.Presentation;
using System;
using System.Windows.Forms.Integration;

namespace E3DAddIn_4
{
    public class MdiWpfWindowCmd : Command
    {
        MdiWindow mdiWindow;

        public MdiWpfWindowCmd(WindowManager windowManager)
        {
            base.Key = "E3DAddIn_4.MdiWpfWindowCmd";

            ElementHost wpfElementHost = new ElementHost();
            MyWpfUserControl myWpfUserControl = new MyWpfUserControl();
            wpfElementHost.Child = myWpfUserControl;

            mdiWindow = windowManager.CreateMdiWindow("CreateMdiWpfWindow", "MyMdiWpfWindow", wpfElementHost);
            mdiWindow.Closing += MdiWindow_Closing;

            this.ExecuteOnCheckedChange = false;
            mdiWindow.Form.TopMost = true;
        }

        private void MdiWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Checked = false;
            mdiWindow.Hide();
            e.Cancel = true;
        }

        private void WindowManager_WindowLayoutLoaded(object sender, EventArgs e)
        {
            this.Checked = mdiWindow.Visible;
        }

        public override void Execute()
        {
            try
            {
                if (mdiWindow.Visible)
                {
                    mdiWindow.Hide();
                }
                else
                {
                    mdiWindow.Show();
                    mdiWindow.Float();
                }
                base.Execute();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}