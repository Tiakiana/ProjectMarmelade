using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    interface IDBController
    {
        IDBController getController();
        void setController(Domain.PersistanceTypes idb);

    }
}
