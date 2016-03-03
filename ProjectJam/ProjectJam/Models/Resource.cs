using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Models
{
    class Resource
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public double Price { get; set; }

        public Resource()
        {

        }

        public Resource(string name, string type, double price, int id = 0)
        {
            Name = name;
            Type = type;
            Price = price;
            if (id != 0)
            {
                Id = id;
            }
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public List<Resource> GetSources()
        {
            return new List<Resource>{ };
        }
    }
}
