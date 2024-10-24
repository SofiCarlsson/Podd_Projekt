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

        // Ny metod för att ta bort kategori med bekräftelse
        public void DeleteKategori(int index)
        {
            if (index < 0 || index >= kategoriRepository.GetAll().Count)
            {
                Console.WriteLine("Ogiltigt index. Kategori kunde inte tas bort.");
                return;
            }

            // Fråga användaren om de är säkra på att de vill ta bort kategorin
            Console.WriteLine("Är du säker på att du vill ta bort denna kategori? (ja/nej)");
            string svar = Console.ReadLine()?.ToLower();

            if (svar == "ja")
            {
                kategoriRepository.Delete(index);
                Console.WriteLine("Kategori har tagits bort.");
            }
            else
            {
                Console.WriteLine("Kategori har inte tagits bort.");
            }
        }
    }
}


