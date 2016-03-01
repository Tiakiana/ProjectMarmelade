using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;

namespace ProjectJam.Persistents
{
    interface IResourceRepository: IGenericRepository<Resource>
    {
        IEnumerable<Resource> GetResources();
    }
}
