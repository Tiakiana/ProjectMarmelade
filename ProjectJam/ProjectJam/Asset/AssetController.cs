using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AssetController
    {
        //Properties:
        internal Asset CurrentAsset { get; private set; }
        Persistance.DBC DBcontroller = new Persistance.DBC();
        
        // Methods:
        public void InsertNewAsset()
        {
            DBcontroller.SaveAsset(CurrentAsset);
        }
        public void GetAsset(int assetID)
        {
           CurrentAsset =  DBcontroller.LoadAsset(assetID);

        }

        public List<string> ShowAssetInfo()
        {
            List<string> assetStringReturnList = DBcontroller.ShowAssetInfo();
            return assetStringReturnList;
        }

        public void PlanMaintenance(int assetID, string description, DateTime plannedDate)
        {

            GetAsset(assetID);
            AssetMaintenance tempMaintenance = new AssetMaintenance( description, plannedDate);
            CurrentAsset.addMaintenance(tempMaintenance);
        }

        public void PerformMaintenance(int assetID)
        {
            GetAsset(assetID);
            CurrentAsset.PerformMaintenance();

        }

        public void CompleteMaintenance(int assetID)
        {

            GetAsset(assetID);
            
            CurrentAsset.CompleteMaintenance();
        }

        public void CreateNewAsset(string name, decimal purchasePrice, string purchaseDate, decimal scrapvalue,  int lifeSpan, string isoperative, DecreciationType inDecreciation)
        {

            Asset tempAsset = new Asset(name, purchasePrice, purchaseDate, scrapvalue, lifeSpan, isoperative, inDecreciation);
            DBcontroller.SaveAsset(tempAsset);
        }


    }
}
