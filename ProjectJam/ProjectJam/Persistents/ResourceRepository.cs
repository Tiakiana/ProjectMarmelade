using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;

namespace ProjectJam.Persistents
{
    class ResourceRepository: Repository<Resource>
    {
        public override void Insert(Resource item)
        {
            base.Insert(item);
        }

        public override void Insert(ref Resource item)
        {
            // Prepare Database parameters
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("name", item.Name);
            param.Add("type", item.Type);
            param.Add("price", item.Price);

            // Database action
            Database db = new Database("addResource", param);
            db.Execute();

            // Rewrite reference object
            Resource temp = new Resource(item.Name, item.Type, item.Price, db.InsertId);
            item = temp;
        }

        public void Insert(string name, string type, double price)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("name", name);
            param.Add("type", type);
            param.Add("price", price);

            // Database action
            Database db = new Database("addResource", param);
            db.Execute();
        }

        public override void Update(Resource item)
        {
            base.Update(item);
        }

        public override void Delete(Resource item)
        {
            base.Delete(item);
            
        }

        public override List<Resource> GetAll()
        {
            Database db = new Database("SELECT * FROM [dbo].[Resources]");
            List<Dictionary<string, object>> result = db.FetchAll(false);
            List<Resource> resources = new List<Resource>();
            foreach (Dictionary<string, object> parent in result)
            {
                Resource source = new Resource();
                foreach (KeyValuePair<string, object> item in parent)
                {
                    Patching(item, ref source);
                }
                resources.Add(source);
            }

            return resources;
        }

        private void Patching(KeyValuePair<string, object> parse, ref Resource source)
        {
            if (parse.Key == "id")
            {
                source.SetId((int)parse.Value);
            }
            else if (parse.Key == "name")
            {
                source.Name = (string)parse.Value;
            }
            else if (parse.Key == "type")
            {
                source.Type = (string)parse.Value;
            }
            else if (parse.Key == "price")
            {
                source.Price = (double)parse.Value;
            }
        }
    }
}
