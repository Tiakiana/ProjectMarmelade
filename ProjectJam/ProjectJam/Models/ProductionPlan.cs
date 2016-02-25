using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Persistents;

namespace ProjectJam.Models
{
    class ProductionPlan
    {
        List<Product> productLine = new List<Product>();

        public void GeneratePlan()
        {
            //productLine = Product.GetProducts();
            Product item = new Product(1, Product.ProductType.Daily, 10, new Recipe());
        }

        public void TestPlan()
        {
            DataFactory data = new DataFactory();

            // Pull false data
            productLine = data.GetProducts(20);

            foreach (Product item in productLine)
            {
                Console.WriteLine("Item {0}: ", item.Type.ToString());
                
                foreach (Resource source in item.Ingredient.Ingredients)
                {
                    Console.WriteLine("Resource: {0}", source.Name);
                }
            }

        }

        public Product OptimizeProduction()
        {
            return new Product();
        }

        public void GetRevenue(Product item)
        {

        }



        private void CalculatePlan()
        {
            
        }
    }
}
