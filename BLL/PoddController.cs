using Models;
using System.Xml;
using System.ServiceModel.Syndication;
using DEL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PoddController
    {
        private PodcastRepository poddRepository;

        public PoddController()
        {
            poddRepository = new PodcastRepository();
        }

        // Hämtar alla poddar från datalagrets poddRepository
        public List<Podd> HämtaAllaPoddar()
        {
            return poddRepository.HämtaAllaPoddar();
        }

        // Metod för att ändra poddens namn
        public void AndraPoddNamn(string rssLank, string nyttNamn)
        {
            poddRepository.AndraPoddNamn(rssLank, nyttNamn);
            poddRepository.SaveChanges(); // Spara ändringar efter att namnet ändrats
        }

        // Metod för att ta bort en podd
        public void TaBortPodd(string rssLank)
        {
            poddRepository.TaBortPodd(rssLank);
            poddRepository.SaveChanges(); // Spara ändringar efter att podden tagits bort
        }

        // Hämtar poddar från ett RSS-flöde
<<<<<<< Updated upstream

        //Skriv en metod för att bara hämta ut namnet 
        public void HämtaPoddarRSS(string rssLank, string valfrittNamn= null, string valdKategori = null)
=======
        public void HämtaPoddarRSS(string rssLank, string valfrittNamn = null, string valdKategori = null)
>>>>>>> Stashed changes
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
                    Kategori = valdKategori
                };

                poddRepository.LäggTillPodd(enPodd); // Lägger till podden
                System.Diagnostics.Debug.WriteLine("Podd tillagd: " + enPodd.Avsnitt.ToString());
            }

            poddRepository.SaveChanges(); // Spara ändringar efter att poddar har lagts till
        }

        // Metod för att uppdatera en podd
        public void UppdateraPodd(Podd uppdateradPodd)
        {

            var befintligPodd = poddRepository.HämtaAllaPoddar().FirstOrDefault(p => p.RSSLank == uppdateradPodd.RSSLank);

            if (befintligPodd != null)
            {
                befintligPodd.Namn = uppdateradPodd.Namn;
                befintligPodd.Kategori = uppdateradPodd.Kategori;

                poddRepository.SaveChanges(); // Spara ändringar efter uppdatering
                System.Diagnostics.Debug.WriteLine("Podd uppdaterad: " + befintligPodd.Namn);
            }
            else
            {
                throw new ArgumentException("Podd inte funnen.");
            }
        }

    }
}







