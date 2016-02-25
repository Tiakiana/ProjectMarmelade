using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class AssetController
    {
        //Properties:
        private Asset CurrentAsset { get; set; }
        AssetDatabaseController DBcontroller = new AssetDatabaseController();

        // Methods:
        public void InsertNewAsset()
        {
            DBcontroller.SaveAsset(CurrentAsset);
        }

        public void GetAsset(int assetID)
        {
            CurrentAsset = DBcontroller.LoadAsset(assetID);
        }

        public void ShowAssetInfo()
        {
            // DO STUFF
        }

        public void PlanMaintenance(int assetID, string description, DateTime plannedDate)
        {
            // PLEASE TEST, GUYS (AND GIRL)
            GetAsset(assetID);
            int newMainID = GetLastMaintenanceID ()+1;
            AssetMaintenance tempMaintenance = new AssetMaintenance(newMainID, description, plannedDate);
            CurrentAsset.addMaintenance(tempMaintenance);
        }

        public void PerformMaintenance(int assetID)
        {
            GetAsset(assetID);
            CurrentAsset.PerformMaintenance(getPlannedMaintenanceID());
            // DO STUFF
        }

        public void CompleteMaintenance(int assetID)
        {
            //PLEASE LOOK IT OVER, GUYS AND DOLL!!
            GetAsset(assetID);
            
            CurrentAsset.CompleteMaintenance(GetLastMaintenanceID());
        }

        private void CreateNewAsset(string name, DateTime purchaseDate, decimal purchasePrice, decimal scrapvalue, int lifeSpan)
        {   
            //PLEASE TO BE TESTING OR READ THROUGH; GUYS (AND GIRL)
            int nextID = GetLastAssetID() + 1;
            CurrentAsset = new Asset(nextID, name, purchaseDate, purchasePrice, scrapvalue, lifeSpan);
        }

        private int GetLastAssetID()
        {
            int lastID = 0;
            // stored procedure call to get last Asset in DB
            return lastID;
        }

        private int GetLastMaintenanceID()
        {
            int lastMainID = 0;
            // stored procedure call to get last Maintenance in DB
            return lastMainID;
        }

        private int GetLastDecreciationID()
        {
            int lastDecreciationID = 0;
            // stored procedure call to get last Decreciation in DB
            return lastDecreciationID;
        }

        private int getPlannedMaintenanceID()
        {
            int plannedMaintenanceID = 0;
            // stored procedure call to get planned maintenanceID in DB
            return plannedMaintenanceID;
        }
        
    }
}
