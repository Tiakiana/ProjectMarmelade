using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;

namespace ProjectJam.Persistents
{
    class ProductLineRepository: Repository<ProductLine>
    {
        public override void Insert(ProductLine item)
        {
            base.Insert(item);
        }

        public override void Update(ProductLine item)
        {
            base.Update(item);
        }

        public override void Delete(ProductLine item)
        {
            base.Delete(item);
        }
    }
}
