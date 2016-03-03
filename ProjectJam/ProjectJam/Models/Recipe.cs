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
        public string Name { get; private set; }
        public List<Resource> Ingredients { get; set; }

        public string Judgement { get; set; }

        public Recipe(string name, List<Resource> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }

        public Recipe(int id, string name, List<Resource> ingredients)
        {
            Id = id;
            Name = name;
            Ingredients = ingredients;
        }
    }
}
