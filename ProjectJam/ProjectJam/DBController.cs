using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Persistance
{
    class DBController
    {
        public static volatile IDBController idbc = null;

        internal static void setController(PersistanceTypes persistance)
        {
            switch (persistance)
            {
                case PersistanceTypes.Persistance1:
                    idbc = new DBC();
                    break;
            }
        }

        internal static IDBController getController()
        {
            return idbc;
        }

    }
}
