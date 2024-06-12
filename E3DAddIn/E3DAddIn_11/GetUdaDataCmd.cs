using Aveva.ApplicationFramework.Presentation;
using Aveva.Core.Database;
using ac = Aveva.Core.Utilities.CommandLine;

namespace E3DAddIn_11
{
    public class GetUdaDataCmd : Command
    {
        public GetUdaDataCmd() 
        {
            base.Key = "E3DAddIn_11.GetUdaDataCmd";
        }

        public override void Execute()
        {
            ac.Command.CreateCommand("$P All Equipment with :myUDA starts with 's'").RunInPdms();
            try
            {
                MDB mdb = MDB.CurrentMDB;
                MdbNameTable mdbNameTable = MdbNameTable.GetMdbNameTable(DbType.Design, DbAttribute.GetDbAttribute(":myuda"), "s", "");

                using (mdbNameTable) 
                {
                    foreach (DbElement elm in mdbNameTable) 
                    {
                        ac.Command.CreateCommand(string.Format("$P Equipment : {0} , myUda : {1}" , elm.GetAsString(DbAttributeInstance.NAME) , elm.GetAsString(DbAttribute.GetDbAttribute(":myuda")))).RunInPdms();
                    }
                }
            }
            catch (System.Exception)
            {
            }
        }
    }
}