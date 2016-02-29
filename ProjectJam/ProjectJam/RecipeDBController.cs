using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjectJam
{
    class RecipeDBController
    {
        private SqlConnection conn = new SqlConnection("Server=ealdb1.eal.local;Database=EJL49_DB;User Id=ejl49_usr;Password=Baz1nga49");

        public void CreateRecipe(string Head, string desc, string ingredient, Categori cat)
        {
            conn.Open();
            string TheSQLCommand = string.Format("EXEC CreateRecipe @Header = {0}, @content = {1}, @date = {2}, @ingredience = {3}", Head, desc, DateTime.Today, ingredient);
            SqlCommand cmdProc = new SqlCommand(TheSQLCommand, conn);
            cmdProc.ExecuteNonQuery();
            conn.Close();
            //Opretter opskriften i DB. 
        }

        public void ViewRecipe(int ID)
        {
            conn.Open();
            string TheSQLCommand = string.Format("EXEC[get recipe] @getid = {0}", ID);
            SqlCommand cmdProc = new SqlCommand(TheSQLCommand, conn);

            string result = "";

            using (SqlDataReader reader = cmdProc.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = result + reader.GetInt32(0) + "ID";  
                }
            }

            conn.Close();

        }
    }
}
