using Models;
using System.Xml;
using System.ServiceModel.Syndication;
using DEL.Repository;

namespace BLL
{
    public class PoddController
    {
        private PodcastRepository poddRepository;

        public PoddController()
        {
            poddRepository = new PodcastRepository();
        }

        //Metod för att hämtar alla poddar från datalagrets poddRepository
        public List<Podd> HämtaAllaPoddar()
        {
            return poddRepository.HämtaAllaPoddar();
        }

        public List<Podd> HämtaAllaPoddar(string kategori)
        {
            return HämtaAllaPoddar().Where(p => p.Kategori == kategori).ToList();
        }


        // Metod för att ändrar poddens namn
        public void AndraPoddNamn(string rssLank, string nyttNamn)
        {
            poddRepository.AndraPoddNamn(rssLank, nyttNamn);
        }

        // Metdod för att tar bort en podd
        public void TaBortPodd(string rssLank)
        {
            poddRepository.TaBortPodd(rssLank);
        }

        // Hämtar poddar från ett RSS-flöde

        //Skriv en metod för att bara hämta ut namnet 
        public void HämtaPoddarRSS(string rssLank, string valfrittNamn = null, string valdKategori = null)
        {
            // Kontrollera om podden med samma RSS-länk redan finns
            List<Podd> allaPoddar = poddRepository.HämtaAllaPoddar();
            if (allaPoddar.Any(p => p.RSSLank == rssLank))
            {
                System.Diagnostics.Debug.WriteLine("Podd med denna RSS-länk finns redan: " + rssLank);
                return;
            }

            var settings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse
            };

            using (XmlReader varXMLlasare = XmlReader.Create(rssLank, settings))
            {
                SyndicationFeed poddFlode = SyndicationFeed.Load(varXMLlasare);

                string poddNamn = valfrittNamn ?? poddFlode.Title.Text;

                Podd enPodd = new Podd
                {
                    Namn = poddNamn,
                    RSSLank = rssLank,
                    Kategori = valdKategori,
                    AvsnittBeskrivningar = new Dictionary<string, string>() // Se till att du har denna struktur i Podd
                };

                foreach (SyndicationItem item in poddFlode.Items)
                {
                    enPodd.Avsnitt.Add(item.Title.Text); // Lägg till avsnittet i listan
                    enPodd.AvsnittBeskrivningar[item.Title.Text] = item.Summary?.Text ?? "Ingen beskrivning tillgänglig"; // Spara beskrivningen
                    System.Diagnostics.Debug.WriteLine("Avsnitt tillagt: " + item.Title.Text);
                }

                poddRepository.LäggTillPodd(enPodd);
                System.Diagnostics.Debug.WriteLine("Podd tillagd: " + enPodd.Namn);
            }
        }



        //Metod för att ändra namnet på en podd.
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

        //Metod för att uppdatera en podd?????????? kolla på denna igen 
        // kolla på igen gör den samma som ovan??
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

