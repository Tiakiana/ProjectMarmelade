using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class QualityTest : IQualityTest
    {

        private int prodID;
        private DateTime date;
        private string qualityTestActivities, expResults, employee,comment, results;

        public QualityTest(int prodID, DateTime date,
                string qualityTestActivities, string expResults,
                 string employee)
        {
            this.prodID = prodID;
            this.date = date;
            this.qualityTestActivities = qualityTestActivities;
            this.expResults = expResults;
            this.employee = employee;
            this.results = null;
            this.comment = null;

        }

        public QualityTest(int prodID, DateTime date,
                string qualityTestActivities, string expResults,
                 string employee, string comment, string results)
        {

           

            this.prodID = prodID;
            this.date = date;
            this.qualityTestActivities = qualityTestActivities;
            this.expResults = expResults;
            this.employee = employee;
            this.results = results;
            this.comment = comment;
        }
    }
}
