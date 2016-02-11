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
        #region temporary variables;
        //changing the result and comment of a quality test
        IQualityTest result = null;
        #endregion


        public QualityTestController()
        { }
            internal string CreateQualityTest(int prodID, DateTime? date, 
                string qualityTestActivities, string expresults,
                 string employee, string comments, string results) {

            IQualityTest iqt = Factory.GetFactory().GetQTF().CreateQualityTest(0,(DateTime) date, qualityTestActivities, expresults, employee, comments, results,false,false);
            Persistance.DBController.getController().createQualityTest(prodID, iqt);
            return "underway";
        }

        internal string GetQualityTest(int ID)
        {
            result = Persistance.DBController.getController().getQualityTest(ID);
            return result.ToString();
        }
        internal string[] GetQualityTestAsArray(int ID) {
            return Persistance.DBController.getController().getQualityTest(ID).ToString2();
        }

        internal string ChangeQualityTest(bool done, bool cHecked, string comment, string result)
        {
            this.result.setComment(comment);
            this.result.setResult(result);
            this.result.setDone(done);
            this.result.setApproved(cHecked);
            Persistance.DBController.getController().saveQualityTest(this.result);
            return "The data has been saved";
        }

        internal void ChangeAllQualityTest(int ID, string testActivties, string result, string expResult, string comment
            , DateTime date, string employee, bool approved, bool done)
        {
            
            Persistance.DBController.getController().changeQualityTest(Factory.GetFactory().GetQTF().CreateQualityTest(ID, date, testActivties, expResult, employee, comment, result, approved, done));
        }
        
    }
}
