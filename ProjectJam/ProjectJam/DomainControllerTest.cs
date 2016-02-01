using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam
{
    class DomainControllerTest
    {
        static DomainControllerTest dct = null;
        
        public static DomainControllerTest getDCT()
        {
            if (dct == null)
            {
                dct = new DomainControllerTest();
            }
            return dct;
        }
        public void onStart(string type)
        {
            switch (type)
            {
                case "M1":
                    DBControllerTest.dbc.setController(PersistanceTypes.M1);
                    break;
                case "M2":
                    DBControllerTest.dbc.setController(PersistanceTypes.M2);
                    break;
                case "M3":
                    DBControllerTest.dbc.setController(PersistanceTypes.M3);
                    break;
                default:
                    break;
            }

        }
        public void createFruit()
        {
            DBControllerTest.dbc.getController().storeFood();
        }
        public void changeFruit()
        {
            DBControllerTest.dbc.getController().changeFood();
        }
    }
}
