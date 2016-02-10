using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Models
{
    class ResourceStock
    {
        public Resource Item { get; private set; }

        public double Weight { get; set; }

        public ResourceStock(Resource item, double weight)
        {
            Item = item;
            Weight = weight;
        }
    }
}
