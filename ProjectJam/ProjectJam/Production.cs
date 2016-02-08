using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Production
    {
        List<IQualityTest> iQualityTest = new List<IQualityTest>();
        internal string ApproveQualityTest()
        {
            return null;
        }
        internal string[] GetQualityTests(int ProdID)
        {
            return null;
        }
        internal string SaveQualityTest(IQualityTest iqt)
        {
            // gør noget effent med iqt i databasen
            iQualityTest.Add(iqt);

            return null;
        }
    }
}
