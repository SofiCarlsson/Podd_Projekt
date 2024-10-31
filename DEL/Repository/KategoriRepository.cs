using Models;
using System.Collections.Generic;
using System.IO;
using DAL;
using System.Linq;

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

        public async Task<List<Kategori>> GetAllAsync()
        {
            return await Task.Run(() => listAvKategori);
        }

        public Kategori GetById(int id)
        {
            return listAvKategori.FirstOrDefault(k => k.Id == id);
        }

        public void Insert(Kategori theObject)
        {
            if (!listAvKategori.Any(k => k.Id == theObject.Id))
            {
                listAvKategori.Add(theObject);
                SaveChanges(); // Spara ändringar direkt
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

        public void Delete(int id)
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
            try
            {
                kategoriSerializer.Serialize(listAvKategori);
                System.Diagnostics.Debug.WriteLine("Save successful: " + filePath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error saving file: " + ex.Message);
            }
        }

        private List<Kategori> LoadFromFile()
        {
            if (!File.Exists(filePath))
            {
                System.Diagnostics.Debug.WriteLine("File does not exist, initializing empty list.");
                return new List<Kategori>();
            }

            try
            {
                var loadedList = kategoriSerializer.Deserialize();
                System.Diagnostics.Debug.WriteLine("Load successful. Items loaded: " + loadedList.Count);
                return loadedList;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading file: " + ex.Message);
                return new List<Kategori>();
            }
        }
    }
}
