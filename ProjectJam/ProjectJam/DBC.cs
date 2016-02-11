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
     /*   public void changeQualityTest(IQualityTest iq)
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
        */
        public IQualityTest getQualityTest(int ID)
        {
            IQualityTest result = null;

            SqlConnection conn = getConnection();

            SqlCommand command = new SqlCommand("LoadQualityTest", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@QualityTestID", ID));
            
            SqlDataReader sdr = command.ExecuteReader();

            while (sdr.Read())
            {
                DateTime date = Convert.ToDateTime(sdr["CheckedDate"]);
                string qualityTestActivities = Convert.ToString(sdr["QualityTestActivities"]);
                string expectedR = Convert.ToString(sdr["expectedResult"]);
                string employee = Convert.ToString(sdr["employee"]);
                bool done = (bool) sdr["done"];
                bool approved = (bool)sdr["approved"]; ;
               
                result = Factory.GetFactory().GetQTF().CreateQualityTest(ID,date,qualityTestActivities,expectedR,employee,null,null,approved,done);
            }
            conn.Close();
            conn.Dispose();
            return result;
        }

        public void saveQualityTest(IQualityTest iq)
        {
            SqlConnection conn = getConnection();

            SqlCommand command = new SqlCommand("approveQualityTest", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@QualityID", iq.getID()));
            command.Parameters.Add(new SqlParameter("@Comment", iq.getComment()));
            command.Parameters.Add(new SqlParameter("@Result", iq.getResult()));
            command.Parameters.Add(new SqlParameter("@Done", iq.getDone()));
            command.Parameters.Add(new SqlParameter("@Approved", iq.getApproved()));

            command.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();
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

        public void changeQualityTest(IQualityTest iq)
        {
            SqlConnection conn = getConnection();

            SqlCommand command = new SqlCommand("UpdateQualityTest", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            #region comments
     /*
    @QualityTestID INT,
	@checkedDate DATE,
	@QualityTestActivities varchar(255),
	@ExpectedResult varchar(255),
	@employee varchar(255),
	@comment varchar(255),
	@result varchar(255),
	@done BIT,
	@approved BIT
    */
            #endregion

            command.Parameters.Add(new SqlParameter("@QualityTestID", iq.getID()));
            command.Parameters.Add(new SqlParameter("@CheckedDate", iq.getCheckedDate()));
            command.Parameters.Add(new SqlParameter("@QualityTestActivities", iq.getQTA()));
            command.Parameters.Add(new SqlParameter("@ExpectedResult", iq.getER()));
            command.Parameters.Add(new SqlParameter("@employee", iq.getEmployee()));
            command.Parameters.Add(new SqlParameter("@done", iq.getDone()));
            command.Parameters.Add(new SqlParameter("@approved", iq.getApproved()));
            command.Parameters.Add(new SqlParameter("@result", iq.getResult()));
            command.Parameters.Add(new SqlParameter("@comment", iq.getComment()));

            command.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();

        }

        public bool CheckProduction(int id) {
            int ID = -1;
            SqlConnection conn = getConnection();


            SqlCommand command = new SqlCommand("ProductionExists", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ProdID", id));

            SqlDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                ID = (int)rd["ProductionID"];

            }
            conn.Close();
            conn.Dispose();
            if (ID == -1)
            {
                return false;
            }
            else {
                return true;
            }

        }

    }
}
