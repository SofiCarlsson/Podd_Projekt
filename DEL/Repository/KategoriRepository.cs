using Models;
using System.Collections.Generic;
using System.IO;
using DAL;

namespace DEL.Repository
{
    public class KategoriRepository : IRepository<Kategori>
    {
        private const string filePath = "kategorier.xml";  // Fil för att spara kategorier
        private Serializer<Kategori> KategoriSerializer;
        private List<Kategori> ListAvKategori;

        public KategoriRepository()
        {
            KategoriSerializer = new Serializer<Kategori>(filePath);
            // Försök att ladda kategorier från fil, annars skapa en tom lista
            ListAvKategori = LoadFromFile();
        }

        // Hämtar alla kategorier
        public List<Kategori> GetAll() 
        {
            return ListAvKategori;
        }

        // Hämtar kategori via ID
        public Kategori GetById(string id)
        {
            return ListAvKategori.Find(k => k.Id.Equals(id));
        }

        // Lägger till en kategori och sparar listan
        public void Insert(Kategori theObject)
        {
            ListAvKategori.Add(theObject);
            SaveChanges();
        }

        // Uppdaterar en kategori och sparar listan
        public void Update(Kategori theNewObject)
        {
            var index = ListAvKategori.FindIndex(k => k.Id == theNewObject.Id);
            if (index != -1)
            {
                ListAvKategori[index] = theNewObject;
                SaveChanges();
            }
            else
            {
                throw new ArgumentException("Category not found.");
            }
        }


        // Tar bort en kategori och sparar listan
        public void Delete(int id)
        {
            var kategori = GetAll().FirstOrDefault(k => k.Id == id);
            if (kategori != null)
            {
                GetAll().Remove(kategori);
                SaveChanges();
            }
        }


        // Sparar kategorierna till en fil genom att serialisera dem
        public void SaveChanges()
        {
            KategoriSerializer.Serialize(ListAvKategori);
        }

        // Laddar kategorier från filen
        private List<Kategori> LoadFromFile()
        {
            // Om filen inte existerar, returnera en tom lista
            if (!File.Exists(filePath))
                return new List<Kategori>();

            // Deserialisera och returnera kategorierna
            return KategoriSerializer.Deserialize();
        }
    }
}
