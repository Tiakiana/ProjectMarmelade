using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;

namespace ProjectJam
{
    class RecipeDBController
    {
        private SqlConnection conn = new SqlConnection("Server=ealdb1.eal.local;Database=EJL49_DB;User Id=ejl49_usr;Password=Baz1nga49");

        public void CreateRecipe(string Head, string desc, string ingredient)
        {
            conn.Open();
            try
            {
                string TheSQLCommand = string.Format("EXEC CreateRecipe @Header = {0}, @content = {1}, @date = {2}, @ingredience = {3}", Head, desc, DateTime.Today, ingredient);
                SqlCommand cmdProc = new SqlCommand(TheSQLCommand, conn);
                cmdProc.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Recipe not Created" + ex.Message, "Failed");
            }
            conn.Close();
            //Opretter opskriften i DB. 
        }
        public string GetRecipeIDName()
        {
            string ReturnString = "";
            conn.Open();
            SqlCommand cmd = new SqlCommand("EXEC GetRecipeIDName", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ReturnString = ReturnString + reader.GetString(1) + " ID: " + reader.GetInt32(0) + "\n";
            }
            reader.Close();
            return ReturnString;
        }
    }
}
