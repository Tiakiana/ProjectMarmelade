using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data;
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
                bool done = (bool)sdr["done"];
                bool approved = (bool)sdr["approved"]; ;

                result = Factory.GetFactory().GetQTF().CreateQualityTest(ID, date, qualityTestActivities, expectedR, employee, null, null, approved, done);
            }
            conn.Close();
            conn.Dispose();
            return result;
        }
        public IQualityTest getFullQualityTest(int ID)
        {
            IQualityTest result = null;

            SqlConnection conn = getConnection();
            //TODO lav en stored procedore der henter hele quality testen
            SqlCommand command = new SqlCommand("LoadFullQualityTest", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@QualityTestID", ID));

            SqlDataReader sdr = command.ExecuteReader();

            while (sdr.Read())
            {
                DateTime date = Convert.ToDateTime(sdr["CheckedDate"]);
                string qualityTestActivities = Convert.ToString(sdr["QualityTestActivities"]);
                string expectedR = Convert.ToString(sdr["expectedResult"]);
                string employee = Convert.ToString(sdr["employee"]);
                string comment = Convert.ToString(sdr["comment"]);
                string results = Convert.ToString(sdr["result"]);
                bool done = (bool)sdr["done"];
                bool approved = (bool)sdr["approved"]; ;

                result = Factory.GetFactory().GetQTF().CreateQualityTest(ID, date, qualityTestActivities, expectedR, employee, comment, results, approved, done);
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

        public bool CheckProduction(int id)
        {
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

        #region Asset
        public List<string> ShowAssetInfo()
        {
            List<string> assetStringList = new List<string>();
            SqlConnection conn = getConnection();

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * from Asset";

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string tempAsset = "Id: " + rdr.GetInt32(0) + " Name: " + rdr.GetString(1);
                    assetStringList.Add(tempAsset);
                }

            }
            catch (SqlException es)
            {
                Console.WriteLine("UPS " + es.Message);
                Console.ReadLine();
            }
            finally
            {
                conn.Close();
            }
            return assetStringList;
        }

        public Asset LoadAsset(int inAssetID)
        {
            Asset returnAsset;
            int tempID = 0;
            string tempname = "UNKNOWN/VOID";
            decimal tempprice = 1000;
            string tempdate = "01/01/1000";
            decimal scrapvalue = 10;
            int lifespan = 0;
            string status = "false";
            Domain.DecreciationType type = Domain.DecreciationType.Lineær;
            SqlConnection conn = getConnection();

            try
            {
                SqlCommand comd = new SqlCommand("spCompoundAssDesc", conn);
                comd.CommandType = CommandType.StoredProcedure;

                comd.Parameters.Add(new SqlParameter("@AssetId", inAssetID));

                SqlDataReader rdr = comd.ExecuteReader();

                while (rdr.Read())
                {
                    tempID = int.Parse(rdr["AssetId"].ToString());
                    tempname = rdr["AssetName"].ToString();
                    tempprice = decimal.Parse(rdr["AssetPurchasePrice"].ToString());
                    tempdate = rdr["AssetPurchaseDate"].ToString();
                    scrapvalue = decimal.Parse(rdr["AssetScrapValue"].ToString());
                    lifespan = int.Parse(rdr["AssetLifeSpan"].ToString());
                    status = rdr["AssetStatus"].ToString();
                    string inType = rdr["DecreciationType"].ToString();

                    switch (inType)
                    {
                        case "Lineær":
                            type = Domain.DecreciationType.Lineær;
                            break;
                        case "Saldo":
                            type = Domain.DecreciationType.Saldo;
                            break;
                        case "Annuitet":
                            type = Domain.DecreciationType.Annuitet;
                            break;
                    }
                }

            }
            catch (SqlException es)
            {
                Console.WriteLine("UPS " + es.Message);
                Console.ReadLine();
            }
            finally
            {
                conn.Close();
            }

            returnAsset = new Asset(tempname, tempprice, tempdate, scrapvalue, lifespan, status, type);
            returnAsset.SetID(tempID);
            return returnAsset;
        }

        public void SaveAsset(Asset inAsset)
        {
            SqlConnection conn = getConnection();
            // StoredProcedureCall

            try
            {

                SqlCommand command = new SqlCommand("sp_Decreciation_insert", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@decType", inAsset.AssetDecreciationList[0].decreciationType.ToString()));
                command.Parameters.Add(new SqlParameter("@decYear", inAsset.AssetDecreciationList[0].DecreciationYear));
                command.Parameters.Add(new SqlParameter("@decValue", inAsset.AssetDecreciationList[0].DecreciationValue));

                SqlCommand cmd = new SqlCommand("spInsertAsset", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@AssetName", inAsset.AssetName));
                cmd.Parameters.Add(new SqlParameter("@AssetPurchasePrice", inAsset.AssetPurchacePrice));
                cmd.Parameters.Add(new SqlParameter("@AssetPurchaseDate", inAsset.AssetPurchaseDate.ToString()));
                cmd.Parameters.Add(new SqlParameter("@AssetScrapValue", inAsset.AssetScrapValue));
                cmd.Parameters.Add(new SqlParameter("@AssetPostedValue", inAsset.AssetPostedValue.ToString()));
                cmd.Parameters.Add(new SqlParameter("@AssetLifeSpan", inAsset.AssetLifeSpan));
                cmd.Parameters.Add(new SqlParameter("@AssetStatus", inAsset.IsOperative.ToString()));


                command.ExecuteNonQuery();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {

                Console.WriteLine("whooops: " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        #endregion

    }
}
