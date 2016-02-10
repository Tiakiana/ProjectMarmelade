using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmeladeAssets
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
        public Asset()
        {
            this.AssetID = 1;// Get autoincrement from DB
            this.AssetName = "Not Applied";
            this.AssetPurchaseDate = DateTime.Today;
            this.AssetPurchacePrice = 1000;
            this.AssetScrapValue = 0;
            this.AssetPostedValue = this.AssetPurchacePrice - this.AssetScrapValue;
            this.AssetLifeSpan = 1;
            this.IsOperative = false;
            this.AssetDecreciationList = new List<AssetDecreciation>();
            this.AssetMaintenanceList = new List<AssetMaintenance>();
        }

        // Methods:
        public void CalculateDecreciations()
        {
            // DO STUFF
        }

    }
}
