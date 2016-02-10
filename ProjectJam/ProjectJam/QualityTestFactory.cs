using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class QualityTestFactory
    {
        internal static QualityTestFactory qtf;
        public static QualityTestFactory getQTF()
        {
            if (qtf == null)
            {
                qtf = new QualityTestFactory();
            }
            return qtf;
        }

        public IQualityTest CreateQualityTest(int prodID, DateTime date,
                string qualityTestActivities, string expresults,
                 string employee, string comment, string results, bool approved, bool done)
        {
            QualityTest qt;
            if (comment == null && results == null)
            {
                qt = new QualityTest(prodID, date, qualityTestActivities, expresults, employee);

            }
            else
            {
                qt = new QualityTest(prodID, date, qualityTestActivities, expresults, employee, comment, results, approved, done);
            }

            return qt;
             
        }


        

        

    }
}
