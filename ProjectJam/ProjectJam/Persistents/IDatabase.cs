using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Persistents
{
    interface IDatabase: IDisposable
    {
        IProductRepository ProductRepository { get; }
        IPlanRepository PlanRepository { get; }
        IRecipeRepository RecipeRepository { get; }
        IResourceRepository ResourceRepository { get; }
        IProductLineRepository ProductLineRepository { get; }
    }
}
