using Models;

namespace DEL
{
    public class PodcastRepository
    {
        private List<Podd> poddLista = new List<Podd>();

        public void LäggTillPodd(Podd podden)
        {
            if (!poddLista.Any(p => p.RSSLank == podden.RSSLank))
            {
                poddLista.Add(podden);
            }
        }

        public List<Podd> HämtaAllaPoddar()
        {
            return poddLista;
        }

        // Ny metod för att ändra poddens namn
        public void AndraPoddNamn(string rssLank, string nyttNamn)
        {
            var podd = poddLista.FirstOrDefault(p => p.RSSLank == rssLank);
            if (podd != null)
            {
                podd.Namn = nyttNamn; // Ändra poddens namn
            }
        }

        // Ny metod för att ta bort en podd baserat på RSS-länk
        public void TaBortPodd(string rssLank)
        {
            var podd = poddLista.FirstOrDefault(p => p.RSSLank == rssLank);
            if (podd != null)
            {
                poddLista.Remove(podd); // Ta bort podden från listan
            }
        }
    }
}
