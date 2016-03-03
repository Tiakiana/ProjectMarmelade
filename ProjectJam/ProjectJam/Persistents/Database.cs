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


        public void Execute(bool storeProcedure = true)
        {
            using (SqlCommand com = new SqlCommand(Query, connection))
            {
                if (storeProcedure)
                {
                    com.CommandType = CommandType.StoredProcedure;
                }

                try
                {
                    // Prepare parameters
                    if (Parameters != null && Parameters.Count != 0)
                    {
                        foreach (KeyValuePair<string, object> item in Parameters)
                        {
                            com.Parameters.AddWithValue("@" + item.Key, item.Value);
                        }
                    }

                    // Catch inserted id
                    InsertId =  (int)com.ExecuteScalar();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
                finally
                {
                    InsertId = 0;
                    com.ExecuteNonQuery();
                }
            }
        }

        public Dictionary<string, object> Fetch(bool storeProcedure = true)
        {
            // Prepare data
            Dictionary<string, object> result = null;

            using (SqlCommand com = new SqlCommand(Query, connection))
            {
                if (storeProcedure)
                {
                    com.CommandType = CommandType.StoredProcedure;
                }

                try
                {
                    // Prepare parameters
                    if (Parameters != null && Parameters.Count != 0)
                    {
                        foreach (KeyValuePair<string, object> item in Parameters)
                        {
                            com.Parameters.AddWithValue("@" + item.Key, item.Value);
                        }
                    }

                    // Execute command
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = new Dictionary<string, object>();
                            // Adding SQL result in to array
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result.Add(reader.GetName(i), reader.GetValue(i));
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }

            return result;
        }

        public List<Dictionary<string, object>> FetchAll(bool storeProcedure = true)
        {
            // Prepare data
            List<Dictionary<string, object>> result = null;

            using (SqlCommand com = new SqlCommand(Query, connection))
            {
                if (storeProcedure)
                {
                    com.CommandType = CommandType.StoredProcedure;
                }

                try
                {
                    // Prepare parameters
                    if (Parameters != null && Parameters.Count != 0)
                    {
                        foreach (KeyValuePair<string, object> item in Parameters)
                        {
                            com.Parameters.AddWithValue("@" + item.Key, item.Value);
                        }
                    }

                    // Execute command
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        result = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            Dictionary<string, object> items = new Dictionary<string, object>();
                            
                            // Adding SQL result in to array
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                items.Add(reader.GetName(i), reader.GetValue(i));
                            }

                            result.Add(items);
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }

            return result;
        }

        private void getParameters(ref SqlCommand command)
        {
            if (Parameters != null && Parameters.Count != 0)
            {
                foreach (KeyValuePair<string, object> item in Parameters)
                {
                    command.Parameters.AddWithValue("@" + item.Key, item.Value);
                }
            }
        }

        private void establish()
        {
            if (ConnectString == null)
            {
                //throw new Exception("Connection string must be defined");
                ConnectString = "Data Source=ealdb1.eal.local;Initial Catalog=EJL49_DB;Persist Security Info=True;User ID=ejl49_usr;Password=Baz1nga49";
            }

            connection = new SqlConnection(ConnectString);
            connection.Open();
        }
    }
}
