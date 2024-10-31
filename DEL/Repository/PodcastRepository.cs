using Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DEL;

namespace DEL.Repository
{
    public class PodcastRepository
    {
        private const string filePath = "poddar.xml"; // Fil för att spara poddar
        private Serializer<Podd> poddSerializer;
        private List<Podd> poddLista;

        public PodcastRepository()
        {
            poddSerializer = new Serializer<Podd>(filePath);
            poddLista = LoadFromFile(); // Ladda befintliga poddar från filen
        }

        public void LäggTillPodd(Podd podden)
        {
            if (!poddLista.Any(p => p.RSSLank == podden.RSSLank))
            {
                poddLista.Add(podden);
                SaveChanges(); // Spara ändringar direkt när podden läggs till
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
                SaveChanges(); // Spara ändringar när namnet ändras
            }
        }


        public void TaBortPodd(string rssLank)
        {
            var podd = poddLista.FirstOrDefault(p => p.RSSLank == rssLank);
            if (podd != null)
            {
                poddLista.Remove(podd);
                SaveChanges(); // Spara ändringar när podden tas bort
            }
        }

        // Sparar poddarna till en fil genom att serialisera dem
        public void SaveChanges()
        {
            poddSerializer.Serialize(poddLista); // Använd serializer för att spara
        }

        // Laddar poddar från filen
        private List<Podd> LoadFromFile()
        {
            // Om filen inte existerar, returnera en tom lista
            if (!File.Exists(filePath))
                return new List<Podd>();

            // Deserialisera och returnera poddarna
            return poddSerializer.Deserialize();
        }
    }
}
