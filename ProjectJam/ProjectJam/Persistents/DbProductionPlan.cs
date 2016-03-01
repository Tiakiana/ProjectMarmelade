using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;

namespace ProjectJam.Persistents
{
    class DbProductionPlan
    {
        public void Save(ProductionPlan plan)
        {
            //using (IDatabase db = new )
        }

        public void Save(ProductionPlan plan, out int id)
        {

            id = 0;
        }

        public void Modify()
        {

        }

        public void Delete()
        {

        }
    }
}
