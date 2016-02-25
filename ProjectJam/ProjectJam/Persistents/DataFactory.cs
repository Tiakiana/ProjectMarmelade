using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;
using System.Security.Cryptography;

namespace ProjectJam.Persistents
{
    class DataFactory
    {
        SHA1Managed sha = new SHA1Managed();
        Random rand = new Random();

        private string getName
        {
            get
            {
                byte[] word = Encoding.ASCII.GetBytes(rand.Next(999999, 99999999).ToString());
                byte[] hash = sha.ComputeHash(word);
                return Convert.ToBase64String(hash);
            }
        }

        public List<Product> GetProducts(int number = 5, bool autofill = true, Recipe content = null)
        {
            //Product item = new Product(1, Product.ProductType.Daily, 10, new Recipe());

            List<Product> items = new List<Product>();

            for (int i = 0; i < number; i++)
            {
                Func<Product.ProductType> getProductType = () => {
                    Product.ProductType type = Product.ProductType.Premium;
                    switch (rand.Next(0,2))
                    {
                        case 0:
                            type = Product.ProductType.Discount;
                            break;
                        case 1:
                            type = Product.ProductType.Daily;
                            break;
                        default:
                            type = Product.ProductType.Premium;
                            break;
                    }
                    return type;
                };
                int gram = rand.Next(0, 9) > 4 ? 50 : 100;
                items.Add(new Product(0, getProductType(), gram, autofill ? GetSingleRecipe() : content));
            }
            return items;
        }

        public List<Recipe> GetRecipes(int number = 5, bool autofill = true, List<Resource> resources = null)
        {
            List<Recipe> ingredients = new List<Recipe>();

            for (int i = 0; i < number; i++)
            {
                ingredients.Add(new Recipe(0, autofill ? GetResources() : resources));
            }

            return ingredients;
        }

        public Recipe GetSingleRecipe(bool autofill = true, List<Resource> resources = null)
        {
            return new Recipe(0, autofill ? GetResources() : resources);
        }

        public List<Resource> GetResources(int number = 5)
        {
            List<Resource> sources = new List<Resource>();

            // Random category
            Func<string> getCategory = () => {
                int sum = rand.Next(1,4);
                if (sum >= 1 && sum <= 2)
                    return "Andet";
                else
                    return "Frugt";
            };
            
            // Generate resource
            for (int i = 0; i < number; i++)
            {
                sources.Add(new Resource(getName, getCategory(), rand.Next(3, 15)));
            }

            return sources;

        }
    }
}
