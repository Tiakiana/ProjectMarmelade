using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TechnicalServices.DatabaseHandler
{
    class ProductDocumationAccess : ProductAccess
    {
        
        public double[,] GetProductSizeCost(string pType)
        {
            double[,] dataA = new double[2,2];
            SqlConnection conn = new SqlConnection(dataBaseAccess);
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductSizeCost", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pType", pType);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.HasRows && reader.Read())
                {
                    dataA[i, 0] = Convert.ToDouble(reader["Psize"]);
                    dataA[i, 1] = Convert.ToDouble(reader["Pprice"]);
                    i++;
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
            return dataA;
        }
        public List<List<string>> GetIngredients(string pName)
        {
            List<List<string>> list = new List<List<string>>();
            SqlConnection conn = new SqlConnection(dataBaseAccess);
            try
            {
                SqlCommand cmd = new SqlCommand("GetIngredients", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pName", pName);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.HasRows && reader.Read())
                {
                    List<string> subList = new List<string>();
                    subList.Add(reader["Ingredients"].ToString());
                    subList.Add(reader["Ratio"].ToString());
                    list.Add(subList);
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
            return list;
        }
        public double GetAmoughtIngredients(string pType)
        {
            double d = 0;
            SqlConnection conn = new SqlConnection(dataBaseAccess);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT PName.ProductTypes,AmoughtIngredients.ProductTypes FROM ProductTypes WHERE @pType = PName.ProductTypes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pType", pType);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.HasRows && reader.Read())
                {
                    double.TryParse(reader["AmoughtIngredients"].ToString(), out d);
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
            return d;
        }

    }
}
