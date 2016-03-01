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
    }
}
