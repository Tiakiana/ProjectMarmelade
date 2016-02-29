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

        public List<Product> PullProducts()
        {
            // Generate Ingredients
            List<Resource> resources = new List<Resource>();
            resources.Add(new Resource("Jordbær", "Frugt", 10));
            resources.Add(new Resource("Solbær", "Frugt", 10));
            resources.Add(new Resource("Hinbær", "Frugt", 10));
            resources.Add(new Resource("Sukker", "Andet", 10));
            resources.Add(new Resource("Salt", "Andet", 10));
            resources.Add(new Resource("Mel", "Andet", 10));

            List<Recipe> recipes = new List<Recipe>();
            recipes.Add(new Recipe(1, resources));
            recipes.Add(new Recipe(2, resources));
            recipes.Add(new Recipe(3, resources));
            recipes.Add(new Recipe(4, resources));
            recipes.Add(new Recipe(5, resources));
            recipes.Add(new Recipe(6, resources));

            List<Product> items = new List<Product>();
            items.Add(new Product(1, Product.ProductType.Premium, 130, recipes[0]));
            items.Add(new Product(1, Product.ProductType.Premium, 300, recipes[1]));
            items.Add(new Product(1, Product.ProductType.Daily, 130, recipes[2]));
            items.Add(new Product(1, Product.ProductType.Daily, 300, recipes[3]));
            items.Add(new Product(1, Product.ProductType.Discount, 500, recipes[4]));

            return items;
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
