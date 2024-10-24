using DEL;
using Models;
using System.Xml;
using System.ServiceModel.Syndication;

namespace BLL
{
    public class Poddkontrollerare
    {
        private PodcastRepository poddRepository;

        public Poddkontrollerare()
        {
            poddRepository = new PodcastRepository();
        }

        // Hämtar alla poddar från datalagrets poddRepository
        public List<Podd> HämtaAllaPoddar()
        {
            return poddRepository.HämtaAllaPoddar();
        }

        // Hämtar poddar från ett RSS-flöde
        public void HämtaPoddarRSS(string rssLank, string valfrittNamn= null)
        {
           // Kontrollera om podden med samma RSS-länk redan finns
           List<Podd> allaPoddar = poddRepository.HämtaAllaPoddar();
           if (allaPoddar.Any(p => p.RSSLank == rssLank))
            {
               // Om det redan finns en podd med samma RSS-länk, hoppa över att lägga till den
               System.Diagnostics.Debug.WriteLine("Podd med denna RSS-länk finns redan: " + rssLank);
                  return;
                }

                // Implementera hämtning av RSS-flöde här
                XmlReader varXMLlasare = XmlReader.Create(rssLank);
            SyndicationFeed poddFlode = SyndicationFeed.Load(varXMLlasare);

            string poddNamn = valfrittNamn ?? poddFlode.Title.Text;

            foreach (SyndicationItem item in poddFlode.Items)
            {
                Podd enPodd = new Podd
                {
                    Namn = poddNamn,
                    RSSLank = rssLank,
                    Avsnitt = item.Title.Text,
                    
                };

                poddRepository.LäggTillPodd(enPodd); //Sparar podden
                System.Diagnostics.Debug.WriteLine("Podd tillagd: " + enPodd.Avsnitt.ToString());
            }
        }
    }
}

