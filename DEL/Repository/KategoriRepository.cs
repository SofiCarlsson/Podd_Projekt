using Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DEL;
using DAL;

namespace DEL.Repository
{
    public class KategoriRepository : IRepository<Kategori>
    {
        private const string filePath = "kategorier.xml";
        private Serializer<Kategori> kategoriSerializer;
        private List<Kategori> listAvKategori;

        public KategoriRepository()
        {
            kategoriSerializer = new Serializer<Kategori>(filePath);
            listAvKategori = LoadFromFile();
        }

        public List<Kategori> GetAll()
        {
            return listAvKategori;
        }

        public Kategori GetById(int id)  // ID är nu int
        {
            return listAvKategori.FirstOrDefault(k => k.Id == id);
        }

        public void Insert(Kategori theObject)
        {
            if (!listAvKategori.Any(k => k.Id == theObject.Id))  // Kontrollera att int-ID inte redan finns
            {
                listAvKategori.Add(theObject);
                SaveChanges();
            }
            else
            {
                throw new ArgumentException("Category already exists.");
            }
        }

        public void Update(Kategori theNewObject)
        {
            var index = listAvKategori.FindIndex(k => k.Id == theNewObject.Id);
            if (index != -1)
            {
                listAvKategori[index] = theNewObject;
                SaveChanges();
            }
            else
            {
                throw new ArgumentException("Category not found.");
            }
        }

        public void Delete(int id) // ID är nu int
        {
            var kategori = listAvKategori.FirstOrDefault(k => k.Id == id);
            if (kategori != null)
            {
                listAvKategori.Remove(kategori);
                SaveChanges();
            }
            else
            {
                throw new ArgumentException("Category not found.");
            }
        }

        public void SaveChanges()
        {
            kategoriSerializer.Serialize(listAvKategori);
        }

        private List<Kategori> LoadFromFile()
        {
            if (!File.Exists(filePath))
                return new List<Kategori>();

            return kategoriSerializer.Deserialize();
        }
    }
}
