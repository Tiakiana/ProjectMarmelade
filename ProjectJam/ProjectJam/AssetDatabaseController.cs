using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Domain
{
    class AssetDatabaseController
    {   
        // Properties
        private SqlConnection AssetConnection { get; set; }
        private List<Asset> AssetTestList { get; }//JUST A TESTER FOR FUNCTIONALITY

        //Methods
        public void InsertAsset(Asset addedAsset)
        {
            // DO STUFF
            AssetTestList.Add(addedAsset);
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
        public void SaveAsset(Asset saveasset)
        {
            // DO STUFF
            // StoredProcedureCall
            AssetTestList.Add(saveasset);
        }

    }
}
