using Aveva.Core.Database;
using Aveva.Core.Presentation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E3DAddIn_8
{
    public partial class NetGridAddinControl : UserControl
    {
        NetGridControl netGridControl = null;
        string tableName;
        Hashtable atts, headings;

        public NetGridAddinControl()
        {
            InitializeComponent();
            AddGridInForm();
            InitGridInForm();
        }

        private void AddGridInForm()
        {
            this.netGridControl = new NetGridControl();
            this.panel1.Controls.Add(this.netGridControl);
        }

        private void InitGridInForm()
        {
            tableName = "Member Info";
            atts = new Hashtable();
            atts[1.0] = "Name";
            atts[2.0] = "Type";
            atts[3.0] = "Owner";

            headings = new Hashtable();
            headings[1.0] = "Name of Item";
            headings[2.0] = "Type of Item";
            headings[3.0] = "Owner of Item";
        }

        private void Add_CE_Mem_Click(object sender, EventArgs e)
        {
            DbElement dbElement = CurrentElement.Element;
            DbElement[] members = dbElement.Members();

            Hashtable items = new Hashtable();
            int i = 1;
            foreach (DbElement member in members) {
                items.Add((double)i, member);
                i++;
            }

            NetDataSource ds = new NetDataSource(tableName, atts, headings, items);
            this.netGridControl.BindToDataSource(ds);
        }
    }
}
