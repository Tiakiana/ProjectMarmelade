using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Persistents
{
    interface IRepository<T>
    {
        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="item">Input object</param>
        void Insert(T item);
        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="item">Input object</param>
        /// <param name="id">Inserted ID (Primary Key)</param>
        void Insert(T item, out int id);
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="item">Input object</param>
        void Update(T item);
        /// <summary>
        /// Update multiple data
        /// </summary>
        /// <param name="items">Input object</param>
        void Update(List<T> items);
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="item">Input object</param>
        void Delete(T item);
        /// <summary>
        /// Delete multiple data
        /// </summary>
        /// <param name="items">Input object</param>
        void Delete(List<T> items);

        /// <summary>
        /// Get All data from the table
        /// </summary>
        /// <returns>List<T></returns>
        List<T> GetAll();
        /// <summary>
        /// Get data by Id
        /// </summary>
        /// <param name="id">Target id</param>
        /// <returns>Type, Object</returns>
        T GetById(int id);
    }
}
