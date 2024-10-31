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
        T GetById(string id);
        void Insert(T theObject);
        void Update(T theNewObject);
        void Delete(string id);
        void SaveChanges();
    }
}

