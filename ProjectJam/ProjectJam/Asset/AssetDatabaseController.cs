using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Domain
{
    class AssetDatabaseController
    {
        // Properties
        Persistance.DBC DBcontroller = new Persistance.DBC();

        private List<Asset> AssetTestList { get; set; }//JUST A TESTER FOR FUNCTIONALITY

        // Constructor
        public AssetDatabaseController()
        {
            // AssetConnection = new SqlConnection("Server=ealdb1.eal.local;Database=ejl49_db;User Id=ejl49_usr;Password=Baz1nga49;");
            AssetTestList = new List<Asset>();
        }

        //Methods

        public void InsertAsset()
        {


        }

        public List<string> ShowAssetInfo()
        {
            List<string> assetStringList = new List<string>();
            SqlConnection conn = new SqlConnection("Server=ealdb1.eal.local;Database=ejl49_db; User ID = ejl49_usr; Password = Baz1nga49");

            try
            {
                conn.Open();

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

        public void PlanMaintenance()
        {
            // DO STUFF
        }

        public void MaintenanceDone()
        {
            // DO STUFF
        }

        public Asset LoadAsset(int inAssetID)
        {
            Asset returnAsset;
            string tempname = "UNKNOWN/VOID";
            decimal tempprice = 1000;
            string tempdate = "01/01/1000";
            decimal scrapvalue = 10;
            int lifespan = 0;
            string status = "false";
            Domain.DecreciationType type = Domain.DecreciationType.Lineær;

            // StoredProcedureCall
            SqlConnection conn = new SqlConnection("Server=ealdb1.eal.local;Database=ejl49_db; User ID = ejl49_usr; Password = Baz1nga49");

            try
            {
                conn.Open();

                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = conn;
                //cmd.CommandText = "SELECT * from Asset";

                SqlCommand comd = new SqlCommand("spCompoundAssDesc", conn);
                comd.CommandType = CommandType.StoredProcedure;

                comd.Parameters.Add(new SqlParameter("@AssetId", inAssetID));

                SqlDataReader rdr = comd.ExecuteReader();

                while (rdr.Read())
                {
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
                    // string Asset = "Id: " + rdr.GetInt32(0) + " Name: " + rdr.GetString(1);

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
            return returnAsset;
        }

        //public void SaveAsset(Asset saveasset)
        //{
        //    // DO STUFF

        //    AssetTestList.Add(saveasset);// blot til test: Skriver til en liste // skriver ikke til databasen.
        //    // StoredProcedureCall
        //    //AssetConnection = new SqlConnection("Server=ealdb1.eal.local;Database=ejl49_db;User Id=ejl49_usr;Password=Baz1nga49;");
        //    try
        //    {

        //        SqlConnection conn = ConnSqlFromDbc();
        //        // DO SHIT to database
        //        SqlCommand cmd = new SqlCommand("spInsertAsset", AssetConnection);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add(new SqlParameter("@AssetName",saveasset.AssetName ));
        //        cmd.Parameters.Add(new SqlParameter("@AssetPurchasePrice",saveasset.AssetPurchacePrice ));
        //        cmd.Parameters.Add(new SqlParameter("@AssetPurchaseDate", saveasset.AssetPurchaseDate.ToString()));
        //        cmd.Parameters.Add(new SqlParameter("@AssetScrapValue",saveasset.AssetScrapValue ));
        //        cmd.Parameters.Add(new SqlParameter("@AssetPostedValue",saveasset.AssetPostedValue ));
        //        cmd.Parameters.Add(new SqlParameter("@AssetLifeSpan",saveasset.AssetLifeSpan ));
        //        cmd.Parameters.Add(new SqlParameter("@AssetStatus",saveasset.IsOperative.ToString() ));

        //        cmd.ExecuteNonQuery();

        //    }
        //    catch (SqlException e)
        //    {

        //        Console.WriteLine("whooops: " + e.Message);
        //    }
        //    finally
        //    {
        //        AssetConnection.Close();
        //        AssetConnection.Dispose();
        //    }




        //}



    }
}
