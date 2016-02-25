using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TechnicalServices.DatabaseHandler
{
    class ProducttIndexAccess : ProductAccess
    {
        public string GetProductNames = "GetProductNames";
        public string GetProtuctNames = "GetProtuctNames";
        public string GetpDocumationTypes = "GetpDocumationTypes";
        public string GetIndex(string s)
        {
            string data = null;
            SqlConnection conn = new SqlConnection(dataBaseAccess);
            try
            {
                    SqlCommand cmd;
                SqlDataReader reader;
                cmd = new SqlCommand(s, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
                while (reader.HasRows && reader.Read())
                {
                    if (data == null)
                    {
                        data = reader.GetString(0);
                    }
                    else
                    {
                        data = data + ";" + reader.GetString(0);
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
    }
}
