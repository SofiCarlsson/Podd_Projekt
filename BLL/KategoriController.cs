using DEL.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class KategoriController
    {
        private IRepository<Kategori> kategoriRepository;

        public KategoriController()
        {
            kategoriRepository = new KategoriRepository();
        }

        // Metod för att skapa en ny kategori.
        public void CreateKategori(int id, string namn)
        {
            Kategori kategoriObj = new Kategori(id, namn);
            kategoriRepository.Insert(kategoriObj);
        }

        // Lista alla kategorier i en Lista.
        public List<Kategori> RetrieveAllKategorier()
        {
            return kategoriRepository.GetAll();
        }

        // Metod för att uppdatera kategorinamnet till ett nytt namn.
        public void UpdateCategory(int id, string newName)
        {
            var category = kategoriRepository.GetAll().FirstOrDefault(k => k.Id == id);

            if (category == null)
            {
                throw new ArgumentException("Category not found.");
            }

            category.Namn = newName;
            kategoriRepository.Update(category); // Kommer att spara ändringar automatiskt
        }

        // Metod för att ta bort kategori med bekräftelse
        public void DeleteKategori(int id)
        {
            var kategori = kategoriRepository.GetById(id.ToString()); // Använd GetById för att hämta kategorin
            if (kategori != null)
            {
                kategoriRepository.Delete(kategori.Id.ToString()); // Ta bort baserat på ID
            }
            else
            {
                throw new ArgumentException("Category not found."); // Hantera fallet där kategorin inte hittades
            }
        }
    }
}





