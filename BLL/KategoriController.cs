﻿using DEL.Repository;
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


        public void CreateKategori(int id, string namn)
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
            var category = kategoriRepository.GetAll().FirstOrDefault(k => k.Id == id);

            if (category == null)
            {
                throw new ArgumentException("Kategori hittades inte.");
            }

            category.Namn = newName;
            kategoriRepository.Update(category);
        }


        public void DeleteKategori(int id)
        {
            var kategori = kategoriRepository.GetAll().FirstOrDefault(k => k.Id == id);
            if (kategori != null)
            {
                kategoriRepository.Delete(id); 
            }
        }

        public List<Kategori> FilterKategorier(string searchKeyword)
        {
            return kategoriRepository.GetAll()
                .Where(k => k.Namn.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }


    }
}