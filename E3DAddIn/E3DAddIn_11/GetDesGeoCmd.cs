using Aveva.ApplicationFramework.Presentation;
using Aveva.Core.Database;
using System.Xml.Linq;
using ac = Aveva.Core.Utilities.CommandLine;

namespace E3DAddIn_11
{
    public class GetDesGeoCmd : Command
    {
        public GetDesGeoCmd() 
        {
            base.Key = "E3DAddIn_11.GetDesGeoCmd";
        }

        public override void Execute() 
        {
            // Scom Name : /ABTA330EE , Element Type of Scom : TEE
            MDB mdb = MDB.CurrentMDB;
            DbElement scom = mdb.FindElement(DbType.Catalog, @"/ABTA330EE");
            DbElement[] allSpcoHasScom = mdb.FindElements(DbType.Catalog, DbAttributeInstance.CATR , scom);

            foreach (DbElement spco in allSpcoHasScom)
            {
                ac.Command.CreateCommand("$P Tee Has Scom " + spco.GetAsString(DbAttributeInstance.NAME)).RunInPdms();

                DbElement[] allTeeHasSpco = mdb.FindElements(DbType.Design, DbAttributeInstance.SPRE , spco);
                foreach (DbElement tee in allTeeHasSpco)
                {
                    ac.Command.CreateCommand(string.Format("$P Name: {0}", tee.GetAsString(DbAttributeInstance.NAMETY))).RunInPdms();
                }
            }
        }
    }
}