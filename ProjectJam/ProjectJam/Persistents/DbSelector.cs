using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjectJam.Persistents
{
    delegate List<object> GetDataDelegate(string query);
    delegate List<List<object>> GetDataListDelegate(string query);
    delegate List<Dictionary<string, object>> GetColumnListDelegate(string query);

    class DbSelector
    {
        public static List<object> GetData(string query)
        {
            return null;
        }
    }
}
