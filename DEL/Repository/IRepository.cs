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
        T GetById(int Id);
        void Insert(T theObject);
        void Update(Kategori theNewObject);
        void Delete(int id);
        void SaveChanges();

    }

}
