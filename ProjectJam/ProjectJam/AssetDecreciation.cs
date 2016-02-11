using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    enum DecreciationType { LinearyMethod, BalanceMethod, AnnuityMethod };
    class AssetDecreciation
    {
        // Properties
        private DecreciationType decreciationType { get; set; }
        private double DecreciationValue { get; set; }
        private double DecreciationPurchasePrice { get; set; }
        private double DecreciationScrapValue { get; set; }
        private double DecreciationLifeSpan { get; set; }
        private int DecriationPercent { get; set; }
        private double DecriationInterest { get; set; }

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
            //Annuitet er sær, der er åbenbart to formler?
            //dn = d1(1 + i)n - 1
            
            //mellemregning for at skrive (1+i)^-n om til p
            double p = Math.Pow((1 + DecriationInterest), -DecreciationLifeSpan);
            //Den anden formel
            double k = (DecreciationPurchasePrice - DecreciationScrapValue) * DecriationInterest / ((1 - p) + DecreciationScrapValue * DecriationInterest);
            // DO STUFF
        }
    }
}
