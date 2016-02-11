using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.SqlClient;

namespace Persistance
{
    internal class DBC : IDBController
    {
        private List<IQualityTest> iQualityTests = new List<IQualityTest>();

        private SqlConnection getConnection()
        {
            // It's a local database sorry :)
            SqlConnection conn = new SqlConnection("Server=ealdb1.eal.local;Database=ejl49_db; User ID = ejl49_usr; Password = Baz1nga49");
            conn.Open();
            return conn;
        }
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

        public void createQualityTest(int prodID, IQualityTest iq)
        {
            SqlConnection conn = getConnection();

            SqlCommand command = new SqlCommand("CreateQualityTestNoComments", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ProductionID", prodID));
            command.Parameters.Add(new SqlParameter("@CheckedDate", iq.getCheckedDate()));
            command.Parameters.Add(new SqlParameter("@QualityTestActivities", iq.getQTA()));
            command.Parameters.Add(new SqlParameter("@ExpectedResult", iq.getER()));
            command.Parameters.Add(new SqlParameter("@Employee", iq.getEmployee()));
            command.Parameters.Add(new SqlParameter("@Done", iq.getDone()));
            command.Parameters.Add(new SqlParameter("@Approved", iq.getApproved()));

            command.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();
          
        }
    }
}
