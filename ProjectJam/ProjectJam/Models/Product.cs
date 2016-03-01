using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Models
{
    
    class Product
    {
        public enum ProductType { Discount, Daily, Premium }
        /// <summary>
        /// Product Managed Size
        /// <para>Premium: Small=175g, Medium=350g, Large=Medium</para>
        /// <para>Daily: Small=400g, Medium=600g, Large=800</para>
        /// <para>Discount: Small=500, Medium=1000g, Large=Medium</para>
        /// </summary>
        public enum ProductSize { Small, Medium, Large }

        /// <summary>
        /// Product Identity
        /// <para>This id got from database, if not defined or id equal to 0, Auto detect as new data</para>
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Product size auto manage the weight of the product
        /// </summary>
        public ProductSize Size { get; private set; }
        /// <summary>
        /// Weight will auto set by size definition
        /// </summary>
        public double Weight { get; private set; }
        public double Price { get; private set; }
        public ProductType Type { get; private set; }
        public Recipe Ingredient { get; private set; }

        public Product()
        {
            
        }

        public Product(ProductType type, ProductSize size, Recipe content)
        {
            Type = type;
            Size = size;
            Ingredient = content;
            ManageData();
        }

        public Product(int id, ProductType type, ProductSize size, Recipe content)
        {
            Id = id;
            Type = type;
            Size = size;
            Ingredient = content;
            ManageData();
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

        /// <summary>
        /// Manage data product weight and price
        /// </summary>
        private void ManageData()
        {
            if (Type == ProductType.Premium)
            {
                if (Size == ProductSize.Small)
                {
                    Weight = 175;
                    Price = 22;
                }
                else
                {
                    Size = ProductSize.Medium;
                    Weight = 350;
                    Price = 38;
                }
            }
            else if (Type == ProductType.Daily)
            {
                if (Size == ProductSize.Small)
                {
                    Weight = 400;
                    Price = 18;
                }
                else if (Size == ProductSize.Medium)
                {
                    Weight = 600;
                    Price = 25;
                }
                else
                {
                    Weight = 800;
                    Price = 31;
                }
            }
            else
            {
                if (Size == ProductSize.Small)
                {
                    Weight = 500;
                    Price = 16;
                }
                else
                {
                    Size = ProductSize.Medium;
                    Weight = 1000;
                    Price = 28;
                }
            }
        }
    }
}
