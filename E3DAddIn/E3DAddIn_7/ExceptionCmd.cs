using Aveva.ApplicationFramework.Presentation;
using Aveva.Core.Database;
using Aveva.Core.Utilities.Messaging;
using System.Windows.Forms;

namespace E3DAddIn_7
{
    public class ExceptionCmd : Command
    {
        private TextBoxCmd textBoxCmd;

        public ExceptionCmd(TextBoxCmd textBoxCmd)
        {
            this.textBoxCmd = textBoxCmd;
            base.Key = "E3DAddIn_7.ExceptionCmd";
        }

        public override void Execute() 
        { 
            try
            {
                string elmentName = this.textBoxCmd.Value.ToString().Trim();
                DbElement dbElement = DbElement.GetElement(elmentName);
                string pspec = dbElement.GetAsString(DbAttributeInstance.PSPE);
                MessageBox.Show("Pspec : " + pspec);
            }
            catch (PdmsException ex)
            {
                MessageBox.Show("Got PDMS Exception : " + ex.Message);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Got PDMS Exception : " + ex.Message);
            }
            
            base.Execute();
        }
    }
}