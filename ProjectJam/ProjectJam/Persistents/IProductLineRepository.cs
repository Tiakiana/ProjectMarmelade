using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;

namespace ProjectJam.Persistents
{
    interface IProductLineRepository: IGenericRepository<ProductLine>
    {
        List<ProductLine> GetProductLine(int id);
    }
}
