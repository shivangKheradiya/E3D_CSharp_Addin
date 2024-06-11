using Aveva.Core.Database;
using Aveva.Core.Utilities.Messaging;
using Aveva.E3D.Standalone;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandAloneE3D
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                Debugger.Launch();
                Standalone.Start();
                Standalone.Open("ProjAPS", "SYSTEM", "XXXXXX", "ALL", out PdmsMessage error);
                MDB mDB = MDB.CurrentMDB;

                Console.WriteLine(mDB.Name);

                Standalone.Finish();
			}
			catch (Exception)
			{
			}
        }
    }
}
