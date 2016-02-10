using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{       enum DecreciationType { LinearyMethod, BalanceMethod, AnnuityMethod};
    class AssetDecreciation
    {
        // Properties
        private DecreciationType decreciationType { get; set; }
        private decimal DecreciationValue { get; set; }
        private decimal DecreciationPurchasePrice { get; set; }
        private decimal DecreciationScrapValue { get; set; }
        private int DecreciationLifeSpan { get; set; }
        public int DecriationPercent { get; set; }

        // Constructors:
        public AssetDecreciation()
        {
            this.decreciationType = DecreciationType.LinearyMethod;
            this.DecreciationValue = (DecreciationPurchasePrice - DecreciationScrapValue) / DecreciationLifeSpan;
            this.DecreciationPurchasePrice = 1000;
            this.DecreciationScrapValue = 0;
            this.DecreciationLifeSpan = 1;
        }
        
        //Methods:
        public void DecreciateLinearyMethod()
        {
            DecreciationValue =
                DecreciationPurchasePrice - DecreciationScrapValue / DecreciationLifeSpan;
            // DO STUFF
        }
        public void DecreciateBalanceMethod()
        {
            DecreciationValue = 
                DecreciationPurchasePrice * DecriationPercent / 100;
            // DO STUFF
        }
        public void DecreciateAnnuityMethod()
        {
            //Annuitet er sær
            dn = d1(1 + i)n - 1
            //og
            k = (𝐴−𝑆)(𝑖/ (1−(1 +𝑖))−𝑛)+𝑆𝑖
            // DO STUFF
        }
    }
}
