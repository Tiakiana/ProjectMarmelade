using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;


namespace ProjectJam
{
    public enum Categori
    {
        Discount = 1,
        Hverdag,
        Luksus
    }
    class RecipeController
    {
        RecipeDBController RecDBCon = new RecipeDBController();
        public void CreateRecipe(string Head, string desc, string ingredient)
        {
            //DBcontroller der opretter opskriften i DB. 
            RecDBCon.CreateRecipe(Head, desc, ingredient);
            Updater();
        }
        public string ViewRecipe(int ID)
        {
            string result = "";
            try
            {
                result = RecDBCon.GetAllRecipes(ID);
            }
            catch (Exception e)
            {
                
                Console.WriteLine("An error occurred: '{0}'", e);
            }
            //Hent opskrift enten fra DB eller liste. 

            return result;
        }

        public string GetRecipeIDName()
        {
            return RecDBCon.GetRecIDName();
            //Henter navn og ID fra alle opskrifter og retunere en lang string som skal skrives ud. 
        }
        public bool JugdeRecipe(int ID, string jugdement)
        {
            try
            {
                RecDBCon.Judgerecipe(ID, jugdement);
                
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Shit failed");
            }
            return true;




       
        }
        public bool DeleteRecipe(int ID)
        {
            //sletter en opskrift fra DB
            try
            {
                RecDBCon.DeleteRecipe(ID);
                //Updater();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed");
            }

            return false;
        }
        public string ViewKnowlegde()
        {
            string viden = RecDBCon.viewKnowledge(); 
            
            return viden;
        }

        public void Updater()
        {

        }
    }
}
