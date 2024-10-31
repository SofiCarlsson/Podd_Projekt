using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEL.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);   // ID är nu av typen int
        void Insert(T theObject);
        void Update(T theNewObject);
        void Delete(int id);  // ID är nu int
        void SaveChanges();
    }
}
