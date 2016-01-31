using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam
{
    class DBControllerTest
    {
        public static IDatabase idb = null;

        public static void StartDatabase(string database)
        {
            switch (database)
            {
                case "MYSQL":
                    idb = new DatabaseTest();
                    break;
                case "Something else":
                    break;
                default:
                    throw new Exception();
            }
        }

    }
}
