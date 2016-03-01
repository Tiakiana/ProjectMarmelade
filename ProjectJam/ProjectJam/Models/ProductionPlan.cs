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
        const int AverageTime = 60;

        public int Id { get; private set; }

        public int ContainerCapacity { get; set; }
        public int ProduceRatePerHour { get; set; }
        public int ProductionTime { get; set; }

        private int MostValuableIndex = -1;
        public List<ProductLine> ItemLines { get; private set; }


        public ProductionPlan(int capacity = 500, int ratePerHour = 200, int productionTime = 240)
        {
            ContainerCapacity = capacity;
            ProduceRatePerHour = ratePerHour;
            ProductionTime = productionTime;
        }

        public void GeneratePlan()
        {
            // Pull every products from database
            List<Product> items = Product.GetProducts();

            // Initiate ProductLine list
            ItemLines = new List<ProductLine>();

            // Prepare ProductLine for calculation
            // Initiate ProductLine Calculation - Calculate()
            foreach (Product item in items)
            {
                ProductLine line = new ProductLine(item, ContainerCapacity, ProduceRatePerHour, ProductionTime);
                line.Calculate();

                ItemLines.Add(line);
            }

            // Re-order ProductLine as Most profitable first
            IEnumerable<ProductLine> temp = ItemLines.OrderByDescending(x => x.RevenueStatistic(AverageTime));
            ItemLines = temp.ToList();

            // Prepare to save to database
            

            // -DONE
        }

        public void GetMostProfitableProduct()
        {

        }
    }
}
