using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Persistents
{
    interface IGenericRepository<T>
    {
        T Create();

        void Insert(T input);
        void Update(T input);
        void Delete(T input);

        IEnumerable<T> FindAll();
        T FindById(int id);
    }
}
