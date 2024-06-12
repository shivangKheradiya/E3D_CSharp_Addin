using Aveva.ApplicationFramework.Presentation;
using Aveva.Core.Database;
using Aveva.Core.Database.Filters;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Forms;
using ACDF = Aveva.Core.Database.Filters;

namespace E3DAddIn_9
{
    public class FilterElementsCmd : Command
    {
        public ACDF.TypeFilter typeFilter;
        public ACDF.AttributeUnsetFilter attributeUnsetFilter;
        public ACDF.AttributeRefFilter attributeRefFilter;
        public ACDF.AndFilter andFilter;

        public ACDF.DBElementCollection collection;

        public FilterElementsCmd()
        {
            base.Key = "E3DAddIn_9.FilterElementsCmd";
        }

        public override void Execute() 
        {
            try
            {
                DbElement ce = CurrentElement.Element;

                // TypeFilter
                CollectTypeForCE(ce);

                // AttributeUnsetFilter
                CollectTypeWithUnsetDescForCE(ce);

                // AttributeRefFilter
                CollectTypeHasOwner(ce);

                // AndFilter
                CollectTypeAndUnsetDescForCE(ce);
            }
            catch (System.Exception) { }
        }

        private void CollectTypeAndUnsetDescForCE(DbElement ce)
        {   
            andFilter = new AndFilter();
            andFilter.Add(typeFilter);
            andFilter.Add(attributeUnsetFilter);

            collection = new ACDF.DBElementCollection(ce, andFilter);

            int i = 0;
            foreach (DbElement element in collection)
            {
                i++;
            }
            MessageBox.Show("For CE, We found " + i.ToString() + " Pipe having unset Description.");
        }

        private void CollectTypeHasOwner(DbElement ce)
        {
            DbElement owner = DbElement.GetElement("/ZONE-PIPING-AREA01");

            attributeRefFilter = new ACDF.AttributeRefFilter(DbAttributeInstance.OWNER, owner);
            collection = new ACDF.DBElementCollection(DbElement.GetElement("/*") , attributeRefFilter);
            int i = 0;
            foreach (DbElement element in collection)
            {
                i++;
            }
            MessageBox.Show("We found " + i.ToString() + " Elements having owner /ZONE-PIPING-AREA01");
        }

        private void CollectTypeWithUnsetDescForCE(DbElement ce)
        {
            attributeUnsetFilter = new ACDF.AttributeUnsetFilter(DbAttributeInstance.DESC);
            collection = new ACDF.DBElementCollection(ce, attributeUnsetFilter);

            int i = 0;
            foreach (DbElement element in collection)
            {
                i++;
            }
            MessageBox.Show("For CE, We found " + i.ToString() + " Elements having unset Description.");
        }

        private void CollectTypeForCE(DbElement ce)
        {
            typeFilter = new ACDF.TypeFilter(DbElementTypeInstance.PIPE);
            collection = new ACDF.DBElementCollection(ce, typeFilter);
            
            int i = 0;
            foreach (DbElement element in collection) 
            {
                i++;
            }
            MessageBox.Show("For CE, We found " + i.ToString() + " Pipes." );
        }
    }
}