using DEL.Repository;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class KategoriController
    {
        IRepository<Kategori> kategoriRepository;

        public KategoriController()
        {
            kategoriRepository = new KategoriRepository();
        }


        //Metod för att skapa en ny kategori.
        public void CreateKategori(int id, string namn)
        {
            Kategori kategoriObj = new Kategori(id, namn);
            kategoriRepository.Insert(kategoriObj);
        }


        //Lista alla kategorier i en Lista.
        public List<Kategori> RetrieveAllKategorier()
        {
            return kategoriRepository.GetAll();
        }


        //Metod för att uppdatera kategorinamnet till ett nytt namn.
        public void UpdateCategory(int id, string newName)
        {
            var category = kategoriRepository.GetAll().FirstOrDefault(k => k.Id == id);

            if (category == null)
            {
                throw new ArgumentException("Category not found.");
            }

            category.Namn = newName;
            kategoriRepository.Update(category);
        }


        // Metod för att ta bort kategori med bekräftelse
        public void DeleteKategori(int id)
        {
            var kategori = kategoriRepository.GetAll().FirstOrDefault(k => k.Id == id);
            if (kategori != null)
            {
                kategoriRepository.Delete(id); // Använd kategori-id för att radera
            }
        }

    }
}
    


