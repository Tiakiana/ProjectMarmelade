using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Persistance
{
    internal class DBC : IDBController
    {
        private List<IQualityTest> iQualityTests = new List<IQualityTest>();

        public void changeQualityTest(IQualityTest iq)
        {
            for (int i = 0; i < iQualityTests.Count; i++)
            {
                if (iQualityTests[i].getID() == iq.getID())
                {
                    iQualityTests.Remove(iQualityTests[i]);
                    iQualityTests.Add(iq);
                    break;
                }
            }
        }

        public IQualityTest getQualityTest(int ID)
        {
            Domain.IQualityTest iq = null;
            foreach (var item in iQualityTests)
            {
                if (item.getID() == ID)
                {
                    iq = item;
                }
            }
            return iq;
        }

        public void saveQualityTest(IQualityTest iq)
        {
            iQualityTests.Add(iq);
        }
    }
}
