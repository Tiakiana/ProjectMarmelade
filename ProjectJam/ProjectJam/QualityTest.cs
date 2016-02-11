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
        private string qualityTestActivities, expResults, employee, comment, results;
        private bool done, approved;
        public QualityTest(int prodID, DateTime date,
                string qualityTestActivities, string expResults,
                 string employee, bool approved, bool done)
        {
            this.prodID = prodID;
            this.date = date;
            this.qualityTestActivities = qualityTestActivities;
            this.expResults = expResults;
            this.employee = employee;
            this.results = null;
            this.comment = null;
            this.done = done;
            this.approved = approved;
        }
        public QualityTest(DateTime date,
                string qualityTestActivities, string expResults,
                 string employee)
        {
            this.prodID = -1;
            this.date = date;
            this.qualityTestActivities = qualityTestActivities;
            this.expResults = expResults;
            this.employee = employee;
            this.results = null;
            this.comment = null;
            this.done = false;
            this.approved = false;
        }
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
            this.done = false;
            this.approved = false;
        }

        public QualityTest(int prodID, DateTime date,
                string qualityTestActivities, string expResults,
                 string employee, string comment, string results, bool done, bool approved)
        {
            this.prodID = prodID;
            this.date = date;
            this.qualityTestActivities = qualityTestActivities;
            this.expResults = expResults;
            this.employee = employee;
            this.results = results;
            this.comment = comment;
            this.done = done;
            this.approved = approved;
        }

        public int getID()
        {
            return prodID;
        }

        public override string ToString()
        {
            return "ID: " + prodID + " Date: " + date + "\nquality test activities: " + qualityTestActivities + " expected results: " + expResults + "\nemployee: " + employee + "\ncomments: " + comment + " results: " + results + "\nIs the test done? " + done + "\nIs the test approved? " + approved;
        }
        public string[] ToString2()
        {
            string[] s = new string[8];
            s[0] = results;
            s[1] = qualityTestActivities;
            s[2] = comment;
            s[3] = expResults;
            s[4] = date.ToString();
            s[5] = approved.ToString();
            s[6] = done.ToString();
            s[7] = employee;
            return s;
            }
        public void setComment(string comment)
        {
            this.comment = comment;
        }
        public void setResult(string results)
        {
            this.results = results;
        }
        public void setApproved(bool done)
        {
            approved = done;
        }
        public void setDone(bool cHecked)
        {
            done = cHecked;
        }
        public DateTime getCheckedDate()
        {
            return date;
        }
        public string getQTA()
        {
            return qualityTestActivities;
        }
        public string getER()
        {
            return expResults;
        }
        public string getEmployee()
        {
            return employee;
        }
        public string getComment()
        {
            return comment;
        }
        public string getResult()
        {
            return results;
        }
        public bool getDone()
        {
            return done;
        }
        public bool getApproved()
        {
            return approved;
        }
    }
}
