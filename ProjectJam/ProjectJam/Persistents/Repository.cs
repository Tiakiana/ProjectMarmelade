using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Persistents
{
    class Repository<T>: IRepository<T>
    {
        public virtual void Insert(T item)
        {

        }

        public virtual void Insert(T item, out int id)
        {
            id = 0;
        }

        public virtual void Update(T item)
        {

        }

        public virtual void Update(List<T> items)
        {

        }

        public virtual void Delete(T item)
        {

        }

        public virtual void Delete(List<T> items)
        {

        }

        public virtual List<T> GetAll()
        {
            return new List<T>();
        }

        public virtual T GetById(int id)
        {
            return default(T);
        }
    }
}
