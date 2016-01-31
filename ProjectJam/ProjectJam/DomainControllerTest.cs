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
        public void onStart(string database)
        {
            DBControllerTest.StartDatabase(database);
        }
        public void createFruit()
        {
            DBControllerTest.idb.createFruit();
        }
        public void changeFruit()
        {
            DBControllerTest.idb.changeFruit();
        }
    }
}
