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
        public int NumberOfTank { get; set; }
        public int MassPerTank { get; set; }
        
        List<Product> productLine = new List<Product>();
        //List<int> productMass = new List<int>();
        //Dictionary<>

        public ProductionPlan()
        {
            PlanDefault();

        }

        public ProductionPlan(int tankCapacity, int mass)
        {
            NumberOfTank = tankCapacity;
            MassPerTank = mass;

            PlanDefault();
        }

        public void GeneratePlan()
        {
            //productLine = Product.GetProducts();
            DataFactory factor = new DataFactory();
            productLine = factor.PullProducts();


            
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

        private void PlanDefault()
        {
            if (MassPerTank <= 0)
            {
                MassPerTank = 200;
            }
            if (NumberOfTank <= 0)
            {
                NumberOfTank = 2;
            }
        }

        private void CalculatePlan()
        {
            
        }
    }
}
