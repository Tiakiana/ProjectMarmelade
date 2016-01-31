using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam
{
    class UITest
    {
        public void testTest()
        {
            UITest ui = new UITest();
            ui.onStart("MYSQL");
            ui.createFruit();
            ui.changeFruit();
            Console.Read();
        }
        public void onStart(string database)
        {
            DomainControllerTest.getDCT().onStart(database);
        }
        public void createFruit()
        {
            DomainControllerTest.getDCT().createFruit();
        }
        public void changeFruit()
        {
            DomainControllerTest.getDCT().changeFruit();
        }
    }
}
