using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Models
{
    class ProductLine : IProduction
    {
        public double ContainerMass { get; set; }

        public int GlassPerHour { get; set; }

        public TimeSpan SpeedPerContainer { get; set; }

        public Product TargetProduct { get; set; }

        public double TotalCost { get; private set; }

        public TimeSpan TotalTime { get; private set; }

        

        /// <summary>
        /// Product line use for production's optimization
        /// </summary>
        /// <param name="product">Product object</param>
        /// <param name="totalWeight">Container's contain weight (kg)</param>
        /// <param name="speedPerContainer">Speed for produce the jams in (minutes)</param>
        /// <param name="itemPerHour">Number of product can produce in an hour</param>
        public ProductLine(Product product, double totalWeight = 500, int speedPerContainer = 240, int itemPerHour = 200)
        {
            SpeedPerContainer = new TimeSpan(0, speedPerContainer, 0);
            TargetProduct = product;
            ContainerMass = totalWeight;
            GlassPerHour = itemPerHour;
        }

        public void Calculate()
        {
            // Unprecise counter
            // Convert hour to seconds
            double totalSeconds = (((ContainerMass * 1000) / TargetProduct.Weight) / GlassPerHour) * 3600;
            // Convert seconds to ticks for more precise time calculation (Damn unclear data)
            long ticks = Convert.ToInt64(totalSeconds * 10000000);

            // Define total production time for the product
            TotalTime = new TimeSpan(ticks);

        }
    }
}
