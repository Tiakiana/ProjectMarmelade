using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ProjectJam.Models;

namespace ProjectJam.Persistents
{
    class Database
    {
        public static string ConnectString { get; set; }

        public string Query { get; set; }
        public int AffectedRows { get; private set; }
        public int InsertId { get; private set; }

        public Dictionary<string, object> Parameters { get; set; }

        private SqlConnection connection;
        private SqlCommand command;
        private static SqlConnection clone = null;
        

        public Database()
        {
            establish();
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
                if (clone == null)
                {
                    clone = new SqlConnection(ConnectString);
                    connection = clone;
                }
                else
                {
                    connection = clone;
                }
                connection.Open();
            }
        }
    }
}
