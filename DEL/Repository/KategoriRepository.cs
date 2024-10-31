using Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DEL;

namespace DEL.Repository
{
    public class KategoriRepository : IRepository<Kategori>
    {
        private const string filePath = "kategorier.xml";  // Fil för att spara kategorier
        private Serializer<Kategori> kategoriSerializer;
        private List<Kategori> listAvKategori;

        public KategoriRepository()
        {
            kategoriSerializer = new Serializer<Kategori>(filePath);
            listAvKategori = LoadFromFile();
        }

        // Hämtar alla kategorier
        public List<Kategori> GetAll()
        {
            return listAvKategori;
        }

        // Hämtar kategori via ID
        public Kategori GetById(string id)
        {
            return listAvKategori.FirstOrDefault(k => k.Id.ToString() == id); // Jämför med sträng
        }

        // Lägger till en kategori och sparar listan
        public void Insert(Kategori theObject)
        {
            if (!listAvKategori.Any(k => k.Id == theObject.Id))
            {
                listAvKategori.Add(theObject);
                SaveChanges(); // Spara ändringar
            }
            else
            {
                throw new ArgumentException("Category already exists.");
            }
        }

        // Uppdaterar en kategori och sparar listan
        public void Update(Kategori theNewObject)
        {
            var index = listAvKategori.FindIndex(k => k.Id == theNewObject.Id);
            if (index != -1)
            {
                listAvKategori[index] = theNewObject;
                SaveChanges(); // Spara ändringar
            }
            else
            {
                throw new ArgumentException("Category not found.");
            }
        }

        // Tar bort en kategori och sparar listan
        public void Delete(string id)
        {
            var kategori = GetById(id);
            if (kategori != null)
            {
                listAvKategori.Remove(kategori);
                SaveChanges(); // Spara ändringar
            }
            else
            {
                throw new ArgumentException("Category not found.");
            }
        }

        // Sparar kategorierna till en fil genom att serialisera dem
        public void SaveChanges()
        {
            kategoriSerializer.Serialize(listAvKategori);
        }

        // Laddar kategorier från filen
        private List<Kategori> LoadFromFile()
        {
            if (!File.Exists(filePath))
                return new List<Kategori>();
            return kategoriSerializer.Deserialize();
        }
    }
}

