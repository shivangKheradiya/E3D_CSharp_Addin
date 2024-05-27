using Aveva.ApplicationFramework;
using Aveva.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E3DAddIn_5
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
            DbEvents.AddHandleUserChanges(new DbEvents.UserChangesEventHandler(UserChangeDeligateTriggerMethod));
            CurrentElement.CurrentElementChanged += CurrentElement_CurrentElementChanged;
        }

        private void CurrentElement_CurrentElementChanged(object sender, CurrentElementChangedEventArgs e)
        {
            MessageBox.Show(e.Element.FullName());
        }

        private void UserChangeDeligateTriggerMethod(DbUserChanges changes)
        {
            DbElement[] dbElements = changes.GetCreations();
            string listOfNames = "Created Element";
            string name;

            foreach (DbElement dbElement in dbElements)
            {
                name = dbElement.GetAsString(DbAttributeInstance.NAME);
                listOfNames += Environment.NewLine + name;
            }
            MessageBox.Show(listOfNames);
        }

        public void Stop()
        {

        }
    }
}
