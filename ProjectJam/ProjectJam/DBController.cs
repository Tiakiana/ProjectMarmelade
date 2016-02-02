using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Persistance
{
    class DBController : IDBController
    {
        public static volatile IDBController dbc = null;

        public void setController(PersistanceTypes persistance)
        {
            switch (persistance)
            {
                case PersistanceTypes.Persistance1:
                    dbc = new DBController_1();
                    break;
            }
        }

        internal IDBController getController()
        {
            return dbc;
        }

    }
}
