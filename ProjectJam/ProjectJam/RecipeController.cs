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
        public void CreateRecipe(string Head, string desc, string ingredient, Categori cat)
        {
            //DBcontroller der opretter opskriften i DB. 
        }
        public string ViewRecipe(int ID)
        {
            //Hent opskrift enten fra DB eller liste. 
            return "";
        }
        public string GetRecipeIDName()
        {
            //Henter navn og ID fra alle opskrifter og retunere en lang string som skal skrives ud. 
            return "";
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
            return false;
        }
        public string ViewKnowlegde()
        {
            //øhm... denne skal hente noget fra DB? 
            return "";
        }
    }
}
