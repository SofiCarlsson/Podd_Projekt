using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEL
{
    public class KategoriRepository
    {
        private List<Kategori> kategorier = new List<Kategori>();

        public List<Kategori> GetAll()
        {
            return kategorier;
        }

        public void Add(Kategori kategori)
        {
            kategorier.Add(kategori);
        }

        public void Update(int id, string nyttNamn)
        {
            var kategori = kategorier.FirstOrDefault(k => k.Id == id);
            if (kategori != null)
            {
                kategori.Namn = nyttNamn;
            }
        }

        public void Remove(int id)
        {
            var kategori = kategorier.FirstOrDefault(k => k.Id == id);
            if (kategori != null)
            {
                kategorier.Remove(kategori);
            }
        }
    }

}
