﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;

namespace ProjectJam.Persistents
{
    class RecipeRepository: Repository<Recipe>
    {
        public override void Insert(Recipe item)
        {
            string query = null;
            foreach (Resource content in item.Ingredients)
            {
                if (query != null)
                {
                    query += string.Format(",({0},{1})", item.Id, content.Id);
                }
                else
                {
                    query += string.Format("({0},{1})", item.Id, content.Id);
                }
            }

            // Assembling SQL Query
            query = "INSERT INTO [dbo].[Ingredients] ([productRecipeID],[resourcesID]) VALUES" + query;

            Database db = new Database(query);
            
        }

        public override void Update(Recipe item)
        {
            base.Update(item);
        }

        public override void Delete(Recipe item)
        {
            base.Delete(item);
        }

        public override List<Recipe> GetAll()
        {
            // Pulling data from database
            Database db = new Database("SELECT * FROM [dbo].[ProductRecipe]");
            List<Dictionary<string, object>> result = db.FetchAll(false);
            List<Recipe> recipes = new List<Recipe>();

            // Convert raw data to usable objects
            foreach (Dictionary<string, object> rec in result)
            {
                string name;
                int id;
                
                foreach (KeyValuePair<string, object> item in rec)
                {
                    
                }
            }

            return recipes;
        }
    }
}
