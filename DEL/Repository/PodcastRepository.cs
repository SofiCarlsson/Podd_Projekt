using Models;
using System.Collections.Generic;
using System.IO;
using DAL;
using System.Linq;

namespace DEL.Repository
{
    public class PodcastRepository
    {
        private const string filePath = "poddar.xml"; 
        private readonly Serializer<Podd> poddSerializer;
        private List<Podd> poddLista;

        public PodcastRepository()
        {
            poddSerializer = new Serializer<Podd>(filePath);
            poddLista = LoadFromFile(); 
        }

        // Lägger till en podd om den inte redan finns
        public void LäggTillPodd(Podd podden)
        {
            if (!poddLista.Any(p => p.RSSLank == podden.RSSLank))
            {
                poddLista.Add(podden);
                SaveChanges();
            }
        }

        public List<Podd> HämtaAllaPoddar()
        {
            return poddLista;
        }

        public void AndraPoddNamn(string rssLank, string nyttNamn)
        {
            var podd = poddLista.FirstOrDefault(p => p.RSSLank == rssLank);
            if (podd != null)
            {
                podd.Namn = nyttNamn;
                SaveChanges();
            }
        }

        public void TaBortPodd(string rssLank)
        {
            var podd = poddLista.FirstOrDefault(p => p.RSSLank == rssLank);
            if (podd != null)
            {
                poddLista.Remove(podd);
                SaveChanges(); 
            }
        }

        public void LäggTillAvsnitt(string rssLank, string avsnittNamn, string avsnittBeskrivning)
        {
            var podd = poddLista.FirstOrDefault(p => p.RSSLank == rssLank);
            if (podd != null)
            {
                podd.LäggaTillAvsnitt(avsnittNamn, avsnittBeskrivning);
                SaveChanges(); 
            }
        }

        public List<Avsnitt> HämtaAvsnittFörPodd(string rssLank)
        {
            var podd = poddLista.FirstOrDefault(p => p.RSSLank == rssLank);
            return podd?.AvsnittLista; 
        }

        public void SaveChanges()
        {
            try
            {
                poddSerializer.Serialize(poddLista);
                System.Diagnostics.Debug.WriteLine("Podcasts saved successfully to file.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error saving podcasts: " + ex.Message);
            }
        }

        // Ladda poddar från XML
        private List<Podd> LoadFromFile()
        {
            if (!File.Exists(filePath))
            {
                System.Diagnostics.Debug.WriteLine("Podcast file does not exist, initializing empty list.");
                return new List<Podd>();
            }
            else
            {
                try
                {
                    var loadedList = poddSerializer.Deserialize();
                    System.Diagnostics.Debug.WriteLine("Podcasts loaded successfully. Count: " + loadedList.Count);
                    return loadedList;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error loading podcasts: " + ex.Message);
                    return new List<Podd>(); 
                }
            }
        }
    }
}