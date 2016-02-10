using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Models
{
    class Resource
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public decimal Price { get; set; }

        public Resource()
        {

        }

        public Resource(string name, string type, decimal price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

        public List<Resource> GetSources()
        {
            return new List<Resource>{ };
        }
    }
}
