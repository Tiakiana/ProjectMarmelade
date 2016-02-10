using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Models
{
    class Recipe
    {
        public int Id { get; private set; }
        public List<Resource> Ingredients { get; set; }

        public string Judgement { get; set; }
    }
}
