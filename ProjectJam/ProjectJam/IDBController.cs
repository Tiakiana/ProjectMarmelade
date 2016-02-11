using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Persistance
{
    interface IDBController
    {
        IQualityTest getQualityTest(int ID);
        void createQualityTest(int prodID, IQualityTest iq);
        void saveQualityTest(IQualityTest iq);
        void changeQualityTest(IQualityTest iq);
    }
}
