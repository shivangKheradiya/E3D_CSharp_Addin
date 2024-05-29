using Aveva.ApplicationFramework.Presentation;
using System;
using System.Windows.Forms;

namespace E3DAddIn_6
{
    public class OperationCmd : Command
    {
        private TextBoxCmd _textBoxCmd;
        private ComboBoxCmd _comboBoxCmd;

        public OperationCmd(TextBoxCmd textBoxCmd, ComboBoxCmd comboBoxCmd) 
        {
            base.Key = "E3DAddIn_6.OperationCmd";
            _textBoxCmd = textBoxCmd;
            _comboBoxCmd = comboBoxCmd;
        }

        public override void Execute()
        {
            string tbValue = _textBoxCmd.Value.ToString();
            string cbValue = _comboBoxCmd.Value.ToString();

            string message = "TextBox Value : " + tbValue + Environment.NewLine +
                             "ComboBox Value : " + cbValue;   

            MessageBox.Show(message);

            base.Execute();
        }
 
        public void Execute(string arg)
        {
            string tbValue = _textBoxCmd.Value.ToString();
            string cbValue = _comboBoxCmd.Value.ToString();
        
            string message = "TextBox Value : " + tbValue + Environment.NewLine +
                             "ComboBox Value : " + cbValue + Environment.NewLine + 
                             "Argument : " + arg;
        
            MessageBox.Show(message);

            base.Execute();
        }

    }
}