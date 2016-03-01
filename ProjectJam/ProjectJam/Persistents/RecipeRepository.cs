using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;

namespace ProjectJam.Persistents
{
    class RecipeRepository: Repository<Recipe>
    {
        public override void Insert(Recipe item)
        {
            base.Insert(item);
        }

        public override void Update(Recipe item)
        {
            base.Update(item);
        }

        public override void Delete(Recipe item)
        {
            base.Delete(item);
        }
    }
}
