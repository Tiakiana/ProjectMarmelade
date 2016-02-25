using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Models
{
    public class ProductionPlan
    {
        List<Product> productLine = new List<Product>();

        public void GeneratePlan()
        {
            productLine = Product.GetProducts();
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
