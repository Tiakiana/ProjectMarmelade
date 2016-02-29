using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;


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
            //En valgt opskrift får tilføjet en bedømmelse. 
            // indsæt viewrecipe metode.


            return false;
        }
        public bool DeleteRecipe(int ID)
        {
            //sletter en opskrift fra DB
            try
            {
                DeleteRecipe slette = new DeleteRecipe();
                int id = Convert.ToInt32(slette.IDtoDelete.Text);
                id = ID;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return false;
        }
        public string ViewKnowlegde()
        {
            //øhm... denne skal hente noget fra DB? 
            return "";
        }
    }
}
