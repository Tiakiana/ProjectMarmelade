using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;

namespace ProjectJam.Persistents
{
    class ProductRepository: Repository<Product>
    {
        
        public override void Insert(Product item)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("price", item.Price);
            param.Add("size", item.Size);
            param.Add("type", item.Type);
            param.Add("recipeID", item.Ingredient.Id);
            Database db = new Database("createProduct", param);
            
        }

        public override void Update(Product item)
        {
            if (item.Id != 0)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("id", item.Id);
                param.Add("price", item.Price);
                param.Add("size", item.Size);
                param.Add("type", item.Type);
                param.Add("recipeID", item.Ingredient.Id);
                Database db = new Database("updateProduct", param);

            }
            else
            {
                throw new Exception("Product must exist in database");
            }
        }

        public override void Delete(Product item)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("id", item.Id);
            Database db = new Database("deleteProduct", param);
        }

        public override List<Product> GetAll()
        {
            Database db = new Database("SELECT * FROM [dbo].[Product]");
            List<Dictionary<string, object>> result = db.FetchAll(false);
            List<Product> products = new List<Product>();

            foreach (Dictionary<string, object> parent in result)
            {
                Product source = new Product();
                foreach (KeyValuePair<string, object> item in parent)
                {
                    Patching(item, ref source);
                }
                products.Add(source);
            }

            return products;
        }

        private void Patching(KeyValuePair<string, object> parse, ref Product source)
        {
            if (parse.Key == "id")
            {
                source.Id = (int)parse.Value;
            }
            else if (parse.Key == "name")
            {
                source.Name = (string)parse.Value;
            }
            else if (parse.Key == "type")
            {
                byte val = (byte)parse.Value;
                Product.ProductType type = Product.ProductType.Premium;
                switch (val)
                {
                    case 0:
                        type = Product.ProductType.Premium;
                        break;
                    case 1:
                        type = Product.ProductType.Daily;
                        break;
                    case 2:
                        type = Product.ProductType.Discount;
                        break;
                }
                source.Type = type;
            }
            else if (parse.Key == "size")
            {
                byte val = (byte)parse.Value;
                Product.ProductSize size = Product.ProductSize.Small;
                switch (val)
                {
                    case 0:
                        size = Product.ProductSize.Small;
                        break;
                    case 1:
                        size = Product.ProductSize.Medium;
                        break;
                    case 2:
                        size = Product.ProductSize.Large;
                        break;
                }
                source.Size = size;
            }
        }
    }
}
