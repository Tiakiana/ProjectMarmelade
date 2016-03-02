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
        public string AssetPurchaseDate { get; private set; }
        public decimal AssetPurchacePrice { get; private set; }
        public decimal AssetScrapValue { get; private set; }
        public decimal AssetPostedValue { get; private set; }
        public int AssetLifeSpan { get; private set; }
        public string IsOperative { get; private set; }
        public decimal PostedValue { get; private set; }
        public List<AssetDecreciation> AssetDecreciationList { get; private set; }
        public List<AssetMaintenance> AssetMaintenanceList { get; private set; }
        public DecreciationType AssetDecreciationType { get; private set; }

        // Constructors:
        public Asset(string name, decimal purchasePrice, string purchaseDate, decimal scrapvalue,  int lifeSpan, string isOperative, DecreciationType decreciationtype)
        {
            
            this.AssetName = name; 
            this.AssetPurchaseDate = purchaseDate;
            this.AssetPurchacePrice = purchasePrice;
            this.AssetScrapValue = scrapvalue;
            this.AssetLifeSpan = lifeSpan;
            this.IsOperative = isOperative;
            this.PostedValue = purchasePrice;
            this.AssetDecreciationList = new List<AssetDecreciation>();
            this.AssetMaintenanceList = new List<AssetMaintenance>();
            this.AssetDecreciationType = decreciationtype;
            AssetDecreciation firstDecreciation = new AssetDecreciation(decreciationtype);
            AssetDecreciationList.Add(firstDecreciation);

        }
        //Overrides
        public override string ToString()
        {
            return ""+AssetID+" "+AssetName+" "+AssetPurchaseDate+" "+AssetPurchacePrice+" "+AssetScrapValue+" "+AssetPostedValue+" "+AssetLifeSpan+" "+IsOperative+" "+AssetDecreciationType;
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
            //this.IsOperative = true;
        }

        public void PerformMaintenance()
        {
            // DOO STUUUFFF
        }
        

    }
}
