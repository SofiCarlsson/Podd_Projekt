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
        public void HämtaPoddarRSS(string rssLank)
        {
            // Implementera hämtning av RSS-flöde här
            XmlReader varXMLlasare = XmlReader.Create(rssLank);
            SyndicationFeed poddFlode = SyndicationFeed.Load(varXMLlasare);

            foreach (SyndicationItem item in poddFlode.Items)
            {
                Podd enPodd = new Podd
                {
                    Rubrik = item.Title.Text
                };

                poddRepository.LäggTillPodd(enPodd); //Sparar podden
                System.Diagnostics.Debug.WriteLine("Podd tillagd: " + enPodd.Rubrik.ToString());
            }
        }
    }
}

