using Aveva.ApplicationFramework.Presentation;
using System;

namespace E3DAddIn_3
{
    public class DockingWindowCmd : Command
    {
        DockedWindow DockedWindow;

        public DockingWindowCmd(WindowManager windowManager)
        {
            base.Key = "E3DAddIn_3.DockingWindowCmd";
            DockedWindow = windowManager.CreateDockedWindow("CreateDockedWindow", "MyDockedWindow", new MyDockedControl(), DockedPosition.Right);
            DockedWindow.SaveLayout = true;
            windowManager.WindowLayoutLoaded += WindowManager_WindowLayoutLoaded;
            DockedWindow.Closed += DockedWindow_Closed;
            this.ExecuteOnCheckedChange = false;
        }

        private void DockedWindow_Closed(object sender, EventArgs e)
        {
            this.Checked = false;
        }

        private void WindowManager_WindowLayoutLoaded(object sender, EventArgs e)
        {
            this.Checked = DockedWindow.Visible;
        }

        public override void Execute()
        {
            try
            {
                if (DockedWindow.Visible)
                {
                    DockedWindow.Hide();
                }
                else
                {
                    DockedWindow.Show();
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