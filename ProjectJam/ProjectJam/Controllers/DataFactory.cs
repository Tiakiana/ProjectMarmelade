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
        public static List<Resource> ResourceList { get; private set; }
        public static List<Product> ProductList { get; private set; }
        public static List<Recipe> RecipeList { get; private set; }

        //private static List<Resource> listResource = new List<Resource>();

        public static void AddResource(string name, string type, double price)
        {
            Task job = new Task(() => {
                // Direct call persistent
                Resource item = new Resource(name, type, price, ResourceList.Count + 1);

                IRepository<Resource> repo = new ResourceRepository();
                repo.Insert(ref item);

                // Initiate ResourceList
                if (ResourceList == null || ResourceList.Count == 0)
                {
                    ResourceList = new List<Resource>();
                }

                ResourceList.Add(item);
            });

            // Start Task
            job.Start();
        }

        public static void AddRecipe(List<Resource> items)
        {

        }

        public static List<Resource> PullResources()
        {
            IRepository<Resource> repo = new ResourceRepository();
            return repo.GetAll();
        }

        
        public static List<Product> PullProducts()
        {
            IRepository<Product> repo = new ProductRepository();
            return repo.GetAll();
        }
        

        //public static void AddProduct(string name)
    }
}
