using Aveva.ApplicationFramework.Presentation;
using System;

namespace E3DAddIn_3
{
    public class MdiWindowCmd : Command
    {
        MdiWindow mdiWindow;

        public MdiWindowCmd(WindowManager windowManager)
        {
            base.Key = "E3DAddIn_3.MdiWindowCmd";
            mdiWindow = windowManager.CreateMdiWindow("CreateMdiWindow", "MyMdiWindow", new MyDockedControl());
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