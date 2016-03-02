using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;
using ProjectJam.Persistents;

namespace ProjectJam.Controllers
{
    class DataFactory
    {
        public static List<Resource> resourceList = new List<Resource>();
        public static List<Product> productList = new List<Product>();
        public static List<Recipe> recipeList = new List<Recipe>();

        public static void AddResource(string name, string type, double price)
        {
            Task job = new Task(() => {
                // Direct call persistent
                Resource item = new Resource(name, type, price);

                IRepository<Resource> repo = new ResourceRepository();
                repo.Insert(ref item);

                resourceList.Add(item);
            });

            // Start Task
            job.Start();
        }

        public static void AddRecipe(List<Resource> items)
        {

        }

        //public static void AddProduct(string name)
    }
}
