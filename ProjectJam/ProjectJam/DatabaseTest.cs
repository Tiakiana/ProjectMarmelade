using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam
{
    class DatabaseTest : IDatabase
    {
        public void changeFruit()
        {
            Console.WriteLine("Fruit has been changed");
        }

        public void createFruit()
        {
            Console.WriteLine("Fruit has been created");
        }
    }
}
