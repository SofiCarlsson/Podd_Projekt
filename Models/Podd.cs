﻿namespace Models
{
    public class Podd
    {
        public string Namn { get; set; }
        public string Id { get; set; }
        public string RSSLank { get; set; }
        public List<Avsnitt> AvsnittLista { get; set; } // Listan över avsnitt
        public string Kategori { get; set; }

        public Podd(string rss)
        {
            AvsnittLista = new List<Avsnitt>(); // Initiera listan i konstruktorn
            RSSLank = rss;
        }

        public Podd()
        {
            AvsnittLista = new List<Avsnitt>(); // Initiera listan även i den tomma konstruktorn
        }

        public void LäggaTillAvsnitt(string namn, string beskrivning)
        {
            if (namn == null || beskrivning == null)
            {
                throw new ArgumentNullException("Namn eller beskrivning kan inte vara null.");
            }

            Avsnitt nyttAvsnitt = new Avsnitt
            {
                Namn = namn,
                AvsnittsBeskrivning = beskrivning
            };

            AvsnittLista.Add(nyttAvsnitt);
        }

        public override string ToString()
        {
            return Namn; // Returnera namnet istället för hela objektet
        }
    }
}

