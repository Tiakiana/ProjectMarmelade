using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectJam.Persistents
{
    delegate void InsertDataDelegate(string query, Dictionary<string, object> param);
    delegate void InsertManagedDelegate(string query, List<SqlParameter> param);


    class DbInsert
    {
        public static void Insert(string query)
        {

        }

        public static void InsertManaged(InsertManagedDelegate manage)
        {
            
        }
    }
}
