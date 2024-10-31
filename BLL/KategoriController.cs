using DEL.Repository;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class KategoriController
    {
        private IRepository<Kategori> kategoriRepository;

        public KategoriController()
        {
            kategoriRepository = new KategoriRepository();
        }

        public void CreateKategori(int id, string namn)  // Nu int id
        {
            Kategori kategoriObj = new Kategori(id, namn);
            kategoriRepository.Insert(kategoriObj);
        }

        public List<Kategori> RetrieveAllKategorier()
        {
            return kategoriRepository.GetAll();
        }

        public void UpdateCategory(int id, string newName)
        {
            var category = kategoriRepository.GetById(id); // Inga konverteringar behövs

            if (category == null)
            {
                throw new ArgumentException("Category not found.");
            }

            category.Namn = newName;
            kategoriRepository.Update(category);
        }

        public void DeleteKategori(int id) // Int ID hanteras direkt
        {
            var kategori = kategoriRepository.GetById(id);
            if (kategori != null)
            {
                kategoriRepository.Delete(id);  // Använd kategori-ID direkt
            }
            else
            {
                throw new ArgumentException("Category not found.");
            }
        }
    }
}





