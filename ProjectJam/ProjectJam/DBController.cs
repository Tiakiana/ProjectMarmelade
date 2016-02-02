using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    class DBController : IDBController
    {
        public static volatile IDBController dbc = null;

        public void setController(PersistanceTypes idb)
        {
            switch (idb)
            {
                case PersistanceTypes.Persistance1:
                    dbc = new DBController_1();
                    break;
            }
        }

        IDBController IDBController.getController()
        {
            return dbc;
        }


    }
}
