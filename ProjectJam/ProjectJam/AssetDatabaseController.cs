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

        private List<Asset> AssetTestList{ get; set; }//JUST A TESTER FOR FUNCTIONALITY

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

        public void ShowAssetInfo(int id)
        {
            // DO STUFF
            Console.WriteLine(AssetTestList[id].ToString());
        }

        public void PlanMaintenance()
        {
            // DO STUFF
        }

        public void MaintenanceDone()
        {
            // DO STUFF
        }

        public Asset LoadAsset(int id)
        {
            // DO STUFF
            // StoredProcedureCall
            Asset someAsset = AssetTestList[id];
            return someAsset;
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
