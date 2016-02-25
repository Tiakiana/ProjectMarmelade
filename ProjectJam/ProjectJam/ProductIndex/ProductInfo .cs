using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalServices.DatabaseHandler;

namespace Model
    {
    class ProductInfo
    {
        double[,] sizeCost = new double[2, 2] { {0,0}, {0,0} };
        string name;
        string type;

        public ProductInfo(string pName, string pType)
        {
            name = pName;
            type = pType;
            GetSizeCost(pType);            
        }
        public void GetSizeCost(string pType)
        {
            ProductDocumationAccess p = new ProductDocumationAccess();
            sizeCost = p.GetProductSizeCost(pType);
        }        
        private string CalculateProductionPrice()
        {
            return "produktionsomkostinger: Kommer senere";
        }
        public override string ToString()
        {
            string s = "Navne: " + name + ";" + "Type: " + type;
            for (int i = 0; i < sizeCost.Length; i++)
            {
                s = s + ";" + "Størrelse: " + sizeCost[i, 0].ToString() + "g, Prise: " + sizeCost[i, 1].ToString() + "kr";
            }
            s = s + ";" + CalculateProductionPrice();
            return s;            
        }
    }
}
