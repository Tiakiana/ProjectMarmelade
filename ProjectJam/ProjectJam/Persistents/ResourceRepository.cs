using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;

namespace ProjectJam.Persistents
{
    class ResourceRepository: Repository<Resource>
    {
        public override void Insert(Resource item)
        {
            base.Insert(item);
        }

        public override void Update(Resource item)
        {
            base.Update(item);
        }

        public override void Delete(Resource item)
        {
            base.Delete(item);
            
        }
    }
}
