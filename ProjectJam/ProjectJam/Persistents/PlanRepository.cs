using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;

namespace ProjectJam.Persistents
{
    class PlanRepository: Repository<ProductionPlan>
    {
        public override void Insert(ProductionPlan item)
        {
            base.Insert(item);
        }

        public override void Update(ProductionPlan item)
        {
            base.Update(item);
        }

        public override void Delete(ProductionPlan item)
        {
            base.Delete(item);
        }
    }
}
