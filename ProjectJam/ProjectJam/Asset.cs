using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Asset
    {
        // Properties
        private int AssetID { get; set; }
        private string AssetName { get; set; }
        private DateTime AssetPurchaseDate { get; set; }
        private decimal AssetPurchacePrice { get; set; }
        private decimal AssetScrapValue { get; set; }
        private decimal AssetPostedValue { get; set; }
        private int AssetLifeSpan { get; set; }
        private bool IsOperative { get; set; }
        private List<AssetDecreciation> AssetDecreciationList { get; set; }
        private List<AssetMaintenance> AssetMaintenanceList { get; set; }

        // Constructors:
        public Asset(int nextID,string name, DateTime purchaseDate, decimal purchasePrice,decimal scrapvalue, int lifeSpan)
        {
            this.AssetID = nextID;
            this.AssetName = name;
            this.AssetPurchaseDate = purchaseDate;
            this.AssetPurchacePrice = AssetPurchacePrice;
            this.AssetScrapValue = scrapvalue;
            this.AssetPostedValue = this.AssetPurchacePrice - this.AssetScrapValue;
            this.AssetLifeSpan = lifeSpan;
            this.IsOperative = false; // set to false. Should manually be set put to 'true' through other method
            this.AssetDecreciationList = new List<AssetDecreciation>();
            this.AssetMaintenanceList = new List<AssetMaintenance>();
        }

        // Methods:
        public void CalculateDecreciations()
        {
            // DO STUFF
        }

        public void addMaintenance(AssetMaintenance newMaintenance)
        {
            AssetMaintenanceList.Add(newMaintenance);
        }

        public void addDecreciation(AssetDecreciation newDecreciation)
        {
            AssetDecreciationList.Add(newDecreciation);
        }

        public void CompleteMaintenance(int mainID)
        {
            AssetMaintenanceList[mainID].CompleteMaintenance();
            IsOperative = true;
        }

        public void PerformMaintenance(int mainID)
        {
            AssetMaintenanceList[mainID].PerformMaintenance();
        }
        

    }
}
