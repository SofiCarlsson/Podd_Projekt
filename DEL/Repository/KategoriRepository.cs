﻿using Models;
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
        public void Update(int index, Kategori theNewObject)
        {
            if (index >= 0 && index < ListAvKategori.Count)
            {
                ListAvKategori[index] = theNewObject;
                SaveChanges();
            }
        }

        // Tar bort en kategori och sparar listan
        public void Delete(int index)
        {
            if (index >= 0 && index < ListAvKategori.Count)
            {
                ListAvKategori.RemoveAt(index);
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
