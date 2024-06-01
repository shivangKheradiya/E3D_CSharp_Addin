using Aveva.ApplicationFramework.Presentation;

namespace E3DAddIn_8
{
    public class GridCmd : Command
    {
        private WindowManager windowsManager;
        private DockedWindow gridWindows;

        public GridCmd(WindowManager windowManager)
        {
            base.Key = "E3DAddIn_8.GridCmd";
            this.windowsManager = windowManager;
            this.gridWindows = this.windowsManager.CreateDockedWindow("Grid", "Grid", new NetGridAddinControl() , DockedPosition.Right);
            this.gridWindows.SaveLayout = true;
            
            this.gridWindows.Closed += GridWindows_Closed;

            this.windowsManager.WindowLayoutLoaded += WindowsManager_WindowLayoutLoaded;
            this.ExecuteOnCheckedChange = false;
        }

        private void WindowsManager_WindowLayoutLoaded(object sender, System.EventArgs e)
        {
            this.Checked = this.gridWindows.Visible;
        }

        private void GridWindows_Closed(object sender, System.EventArgs e)
        {
            this.Checked = false;
        }

        public override void Execute()
        {
            try
            {
                if (this.gridWindows.Visible)
                {
                    this.gridWindows.Hide();
                }
                else
                {
                    this.gridWindows.Show();
                }
            }
            catch (System.Exception)
            {

            }
        }
    }
}