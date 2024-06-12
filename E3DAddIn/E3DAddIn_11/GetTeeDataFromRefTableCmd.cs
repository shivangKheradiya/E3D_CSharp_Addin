using Aveva.ApplicationFramework.Presentation;
using Aveva.Core.Database;
using ac = Aveva.Core.Utilities.CommandLine;

namespace E3DAddIn_11
{
    public class GetTeeDataFromRefTableCmd : Command
    {
        public GetTeeDataFromRefTableCmd() 
        {
            base.Key = "E3DAddIn_11.GetTeeDataFromRefTableCmd";
        }

        public override void Execute() 
        {
            MDB mdb = MDB.CurrentMDB;
            Db[] allDbsInMdb = mdb.GetDBArray(DbType.Design);

            foreach (Db db in allDbsInMdb)
            {
                ac.Command.CreateCommand("$P Tee Elements For " +  db.Name).RunInPdms();

                RefTable elementsHavingSpref = RefTable.GetRefTable(db, DbAttributeInstance.SPRE);

                foreach (DbElement element in elementsHavingSpref)
                {
                    if (element.ElementType.Equals(DbElementTypeInstance.TEE))
                    {
                        ac.Command.CreateCommand(string.Format("$P Spref: {0} , Name: {1}", element.GetAsString(DbAttributeInstance.SPRE), element.GetAsString(DbAttributeInstance.NAMETY))).RunInPdms();
                    }
                }
            }
        }
    }
}