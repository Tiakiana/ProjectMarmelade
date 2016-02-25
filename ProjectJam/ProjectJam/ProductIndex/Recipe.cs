using System.Collections.Generic;
using TechnicalServices.DatabaseHandler;

namespace Model
{
    class Recipe
    {
        List<List<string>> IList = new List<List<string>>();
        public Recipe(string pName, string pType)
        {
            ProductDocumationAccess p = new ProductDocumationAccess();
            IList = p.GetIngredients(pName);
            CalculateUse(p.GetAmoughtIngredients(pType));
        }
        private void CalculateUse(double amought)
        {
            double setProductionSize = 5000;
            for (int i = 0; i < IList.Count; i++)
            {
                double temp = 0;
                double.TryParse(IList[i][1], out temp);
                temp = temp * setProductionSize * amought;
                IList[i][1] = temp.ToString();
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
