using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmeladeAssets
{       enum DecreciationType { LinearyMethod, BalanceMethod, AnnuityMethod};
    class Decreciation
    {
        // Properties
        private DecreciationType decreciationType { get; set; }
        private decimal DecreciationValue { get; set; }
        private decimal DecreciationPurchasePrice { get; set; }
        private decimal DecreciationScrapValue { get; set; }
        private int DecreciationLifeSpan { get; set; }

        // Constructors:
        public Decreciation()
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
            // DO STUFF
        }
        public void DecreciateBalanceMethod()
        {
            // DO STUFF
        }
        public void DecreciateAnnuityMethod()
        {
            // DO STUFF
        }
    }
}
