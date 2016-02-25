using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Models
{
    public class Product
    {
        public enum ProductType { Discount, Daily, Premium }

        public int Id { get; private set; }
        public double Weight { get; private set; }
        public ProductType Type { get; private set; }
        public Recipe Ingredient { get; private set; }

        public Product()
        {

        }

        public Product(int id, ProductType type, double weight, Recipe content)
        {
            Id = id;
            Type = type;
            Weight = weight;
            Ingredient = content;
        }

        public void Save()
        {
            // Saving data to database if Id is not initiate
            if (Id == 0)
            {
                
            }
        }

        public static List<Product> GetProducts()
        {
            return new List<Product>();
        }

        public void GetIngredient()
        {

        }
    }
}
