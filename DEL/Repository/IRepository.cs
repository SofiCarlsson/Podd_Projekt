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
        T GetById(string Id);
        void Insert(T theObject);
        void Update(int index, T theObject);
        void Delete(int index);
        void SaveChanges();

    }

}
