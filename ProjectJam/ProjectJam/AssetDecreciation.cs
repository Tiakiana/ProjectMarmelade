using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum DecreciationType { Lineær, Saldo, Annuitet };
    class AssetDecreciation
    {
        // Properties
        public DecreciationType decreciationType { get;private set; }
        public decimal DecreciationValue { get; private set; }
        public int DecreciationYear { get; private set; }
        // ER DISSE PROPERTIES NØDVENDIGE, ELLER SKAL DE VÆRE INPUT-PARAMETRE?
        private decimal DecreciationPurchasePrice { get; set; }
        private decimal DecreciationScrapValue { get; set; }
        private decimal DecreciationLifeSpan { get; set; }
        private decimal DecriationPercent { get; set; }
        private decimal DecriationInterest { get; set; }


        // Constructors:
        public AssetDecreciation(DecreciationType decrecType)
        {
            this.decreciationType = decrecType;
            this.DecreciationValue = 0;
            this.DecreciationYear = 2016;
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
           
            // decimal p = Math.Pow((1 + DecriationInterest), -DecreciationLifeSpan);
            
            //Den anden formel
           
            // decimal k = (DecreciationPurchasePrice - DecreciationScrapValue) * DecriationInterest / ((1 - p) + DecreciationScrapValue * DecriationInterest);
            
            // DO STUFF
        }


    }
}
