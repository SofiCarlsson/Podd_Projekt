using Models;
using System.Xml;
using System.ServiceModel.Syndication;
using DEL.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class PoddController
    {
        private readonly PodcastRepository poddRepository;

        public PoddController()
        {
            poddRepository = new PodcastRepository();
        }

        // Hämtar alla poddar
        public List<Podd> HämtaAllaPoddar()
        {
            return poddRepository.HämtaAllaPoddar();
        }

        // Hämtar poddar baserat på kategori
        public List<Podd> HämtaAllaPoddar(string kategori)
        {
            return HämtaAllaPoddar().Where(p => p.Kategori == kategori).ToList();
        }

        // Ändrar namnet på en podd
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
        public async Task HämtaPoddarRSSAsync(string rssLank, string valfrittNamn = null, string valdKategori = null)
        {
            // Kontrollera om podden med samma RSS-länk redan finns
            if (poddRepository.HämtaAllaPoddar().Any(p => p.RSSLank == rssLank))
            {
                System.Diagnostics.Debug.WriteLine("Podd med denna RSS-länk finns redan: " + rssLank);
                return;
            }

            var settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Parse };

            using (XmlReader varXMLlasare = XmlReader.Create(rssLank, settings))
            {
                var poddFlode = await Task.Run(() => SyndicationFeed.Load(varXMLlasare));

                var poddNamn = valfrittNamn ?? poddFlode.Title.Text;

                var enPodd = new Podd
                {
                    RSSLank = rssLank,
                    Namn = poddNamn,
                    Kategori = valdKategori
                };

                foreach (var item in poddFlode.Items)
                {
                    // Lägga till avsnitt med namn och beskrivning
                    enPodd.LäggaTillAvsnitt(item.Title.Text, item.Summary?.Text ?? "Ingen beskrivning tillgänglig");
                    System.Diagnostics.Debug.WriteLine("Avsnitt tillagt: " + item.Title.Text);
                }

                poddRepository.LäggTillPodd(enPodd);
                System.Diagnostics.Debug.WriteLine("Podd tillagd: " + enPodd.Namn);
            }
        }

        // Ändrar namnet och kategorin på en podd
        public void AndraPodd(string gammaltNamn, string nyttNamn, string nyKategori)
        {
            var podd = poddRepository.HämtaAllaPoddar().FirstOrDefault(p => p.Namn == gammaltNamn);
            if (podd != null)
            {
                podd.Namn = nyttNamn;
                podd.Kategori = nyKategori; // Uppdatera kategori
                System.Diagnostics.Debug.WriteLine("Podd uppdaterad: " + podd.Namn);
                poddRepository.SaveChanges(); // Spara ändringarna
            }
        }

        // Uppdaterar en podd
        public void UppdateraPodd(Podd uppdateradPodd)
        {
            var befintligPodd = poddRepository.HämtaAllaPoddar().FirstOrDefault(p => p.RSSLank == uppdateradPodd.RSSLank);
            if (befintligPodd != null)
            {
                befintligPodd.Namn = uppdateradPodd.Namn;
                befintligPodd.Kategori = uppdateradPodd.Kategori;
                // Här kan du även uppdatera avsnitten om det behövs
                poddRepository.SaveChanges(); // Spara ändringarna
            }
        }
    }
}

