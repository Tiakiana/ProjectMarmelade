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
        public int AssetID { get; private set; } 
        public string AssetName { get; private set; }
        public DateTime AssetPurchaseDate { get; private set; }
        public decimal AssetPurchacePrice { get; private set; }
        public decimal AssetScrapValue { get; private set; }
        public decimal AssetPostedValue { get; private set; }
        public int AssetLifeSpan { get; private set; }
        public bool IsOperative { get; private set; }
        public List<AssetDecreciation> AssetDecreciationList { get; private set; }
        public List<AssetMaintenance> AssetMaintenanceList { get; private set; }

        // Constructors:
        public Asset(string name, DateTime purchaseDate, decimal purchasePrice,decimal scrapvalue, int lifeSpan)
        {
            
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
        //Overrides
        public override string ToString()
        {
            return ""+AssetID+" "+AssetName+" "+AssetPurchaseDate+" "+AssetPurchacePrice+" "+AssetScrapValue+" "+AssetPostedValue+" "+AssetLifeSpan+" "+IsOperative;
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

        public void CompleteMaintenance()
        {
            //AssetMaintenanceList.Last().
            this.IsOperative = true;
        }

        public void PerformMaintenance()
        {
            // DOO STUUUFFF
        }
        

    }
}
