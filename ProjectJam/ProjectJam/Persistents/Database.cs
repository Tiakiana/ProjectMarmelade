using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ProjectJam.Persistents
{
    class Database
    {
        public static string ConnectString { get; set; }

        public string Query { get; set; }
        public Dictionary<string, object> Parameters { get; set; }

        private SqlConnection connection;
        private SqlCommand command;
        

        public Database()
        {
            establish();
            using (IDatabase data = new Data())
            {
                
            }
        }

        public Database(string query)
        {
            establish();
            Query = query;
        }

        public Database(string query, Dictionary<string, object> param)
        {
            establish();
            Query = query;
            Parameters = param;
        }


        public void Execute()
        {

        }

        public void Fetch()
        {

        }

        private void establish()
        {
            if (ConnectString == null)
            {
                throw new Exception("Connection string must be defined");
            }
            else
            {
                connection = new SqlConnection(ConnectString);
                connection.Open();
            }
        }
    }
}
