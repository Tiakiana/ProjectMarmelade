﻿using System;
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
                string TheSQLCommand = string.Format("EXEC [CreateRecipe] @header = '{0}', @content = '{1}', @date = '{2}', @ingredience = '{3}'", Head, desc, DateTime.Today.ToString(), ingredient);
                SqlCommand cmdProc = new SqlCommand(TheSQLCommand, conn);
                cmdProc.ExecuteNonQuery();
                MessageBox.Show("Recipe Created ", "Succes");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Recipe not Created " + ex.Message, "Failed");
            }
            conn.Close();
            //Opretter opskriften i DB. 
        }
        public string GetRecIDName()
        {
            string ReturnString = "";
            conn.Open();
            SqlCommand cmd = new SqlCommand("EXEC [get all names and header]", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ReturnString = ReturnString + reader.GetString(1) + " ID: " + reader.GetInt32(0) + "\n";
            }
            reader.Close();
            conn.Close();

            return ReturnString;
        }
        public void DeleteRecipe(int ID)
        {
            //Open connection
            conn.Open();

            //Useing the delete recipe stored procedure. Takes in 1 value.
            SqlCommand command = new SqlCommand("Delete recipe", conn);

            //Defines the commandtype
            command.CommandType = CommandType.StoredProcedure;
            //Defines the parameter
            command.Parameters.Add(new SqlParameter("@deleteID", ID));
            //executes the command
            command.ExecuteNonQuery();

            //Close connection
            conn.Close();
        }
        public void Judgerecipe(int ID, string Judgement)
        {
            conn.Open();
                try
            {
                string TheSQLCommand = string.Format("EXEC [Judge recipe] @Recipe = '{0}', @Judgement = '{1}', @Date = '{2}'", ID, Judgement, DateTime.Today.ToString());
                SqlCommand JudgeCmd = new SqlCommand(TheSQLCommand, conn);
                JudgeCmd.ExecuteNonQuery();
                MessageBox.Show("Judgement has been saved ");
            }
            catch (Exception e)
            {

                MessageBox.Show("Judgement not Created " + e.Message, "Failed");
            }
           

        }
        
    }
}
