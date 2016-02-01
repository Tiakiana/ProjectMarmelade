using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam
{
    class DBControllerTest : IDBController
    {
        public static volatile IDBController dbc = null;

       
        public void setController(PersistanceTypes idb)
        {
            switch (idb)
            {
                case PersistanceTypes.M1:
                    dbc = new DBControllerTest();
                    break;
                case PersistanceTypes.M2:
                    dbc = new DBControllerTest2();
                    break;
                case PersistanceTypes.M3:
                    dbc = new DBControllerTest3();
                    break;
                default:
                    break;
            }
        }

        public void storeFood()
        {
            throw new NotImplementedException();
        }
        public void changeFood()
        {
            throw new NotImplementedException();
        }

        IDBController IDBController.getController()
        {
            return dbc;
        }


    }
}
