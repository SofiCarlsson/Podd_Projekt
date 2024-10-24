using DEL;
using Models;
using System.Xml;
using System.ServiceModel.Syndication;

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

        // Ändrar poddens namn
        public void AndraPoddNamn(string rssLank, string nyttNamn)
        {
            poddRepository.AndraPoddNamn(rssLank, nyttNamn);
        }

        // Tar bort en podd
        public void TaBortPodd(string rssLank)
        {
            poddRepository.TaBortPodd(rssLank);
        }

        // Hämtar poddar från ett RSS-flöde
        public void HämtaPoddarRSS(string rssLank, string valfrittNamn= null, string valdKategori = null)
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

                poddRepository.LäggTillPodd(enPodd); //Sparar podden
                System.Diagnostics.Debug.WriteLine("Podd tillagd: " + enPodd.Avsnitt.ToString());
            }
        }
        public void AndraPodd(string gammaltNamn, string nyttNamn, string nyKategori)
        {
            var podd = poddRepository.HämtaAllaPoddar().FirstOrDefault(p => p.Namn == gammaltNamn);

            if (podd != null)
            {
                podd.Namn = nyttNamn;
                podd.Kategori = nyKategori; // Uppdatera kategori
                System.Diagnostics.Debug.WriteLine("Podd uppdaterad: " + podd.Namn);
            }
        }
        public void UppdateraPodd(Podd uppdateradPodd)
        {
            // Hitta den befintliga podden i listan och ersätt den med den uppdaterade
            var befintligPodd = poddRepository.HämtaAllaPoddar().FirstOrDefault(p => p.RSSLank == uppdateradPodd.RSSLank);

            if (befintligPodd != null)
            {
                befintligPodd.Namn = uppdateradPodd.Namn;
                befintligPodd.Kategori = uppdateradPodd.Kategori;
            }
        }

    }
}

