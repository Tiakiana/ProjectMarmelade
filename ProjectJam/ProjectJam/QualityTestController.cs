using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Domain
{
    internal class QualityTestController
    {
        public static QualityTestController qtc;
        public static QualityTestController getQTC()
        {
            if (qtc == null)
            {
                qtc = new QualityTestController();
            }
            return qtc;
        }


        public QualityTestController()
        { }
            internal string CreateQualityTest(int prodID, DateTime date, 
                string qualityTestActivities, string expresults,
                 string employee, string comments, string results) {
            Factory.GetFactory().GetQTF().CreateQualityTest(prodID, date, qualityTestActivities, expresults, employee, comments, results);
            return "underway";

        }


        }
}
