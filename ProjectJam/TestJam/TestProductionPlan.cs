using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectJam;
using ProjectJam.Models;

namespace TestJam
{
    [TestClass]
    public class TestProductionPlan
    {
        Product Item;
        ProductLine ItemLine;
        //ProductionPlan Plan;


        [TestMethod]
        public void TestProduct()
        {
            Item = new Product(Product.ProductType.Premium, Product.ProductSize.Small, null);
        }

        [TestMethod]
        public void TestProductLine()
        {
            Item = new Product(Product.ProductType.Premium, Product.ProductSize.Small, null);
            ItemLine = new ProductLine(Item);
            ItemLine.Calculate();
            double result = ItemLine.RevenueStatistic(60);
        }

        [TestMethod]
        public void TestPlan()
        {
            
        }
    }
}
