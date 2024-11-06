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

        public List<Podd> HämtaAllaPoddar()
        {
            return poddRepository.HämtaAllaPoddar();
        }

        public List<Podd> HämtaAllaPoddar(string kategori)
        {
            return HämtaAllaPoddar().Where(p => p.Kategori == kategori).ToList();
        }

        public void AndraPoddNamn(string rssLank, string nyttNamn)
        {
            poddRepository.AndraPoddNamn(rssLank, nyttNamn);
        }

        public void TaBortPodd(string rssLank)
        {
            poddRepository.TaBortPodd(rssLank);
        }

        public async Task<string> HämtaPoddarRSSAsync(string rssLank, string valfrittNamn = null, string valdKategori = null)
        {
            if (poddRepository.HämtaAllaPoddar().Any(p => p.RSSLank == rssLank))
            {
                return "Podd med denna RSS-länk finns redan.";
            }

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(rssLank);
                    response.EnsureSuccessStatusCode();

                    var rssInnehall = await response.Content.ReadAsStringAsync();
                    var settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Parse };

                    using (var stringReader = new StringReader(rssInnehall))
                    using (XmlReader varXMLlasare = XmlReader.Create(stringReader, settings))
                    {
                        var poddFlode = SyndicationFeed.Load(varXMLlasare);

                        if (poddFlode == null || string.IsNullOrEmpty(poddFlode.Title?.Text))
                        {
                            return "Ogiltigt RSS-flöde: Saknar titel.";
                        }

                        var poddNamn = valfrittNamn ?? poddFlode.Title.Text;

                        var enPodd = new Podd
                        {
                            RSSLank = rssLank,
                            Namn = poddNamn,
                            Kategori = valdKategori
                        };

                        foreach (var item in poddFlode.Items)
                        {
                            enPodd.LäggaTillAvsnitt(item.Title.Text, item.Summary?.Text ?? "Ingen beskrivning tillgänglig");
                        }

                        poddRepository.LäggTillPodd(enPodd);
                        return null;
                    }
                }
            }
            catch (HttpRequestException)
            {
                return "Fel vid hämtning av RSS-flödet. Kontrollera att RSS-länken är giltig och tillgänglig.";
            }
            catch (XmlException)
            {
                return "Fel vid parsing av XML. Kontrollera att RSS-flödet har ett korrekt format.";
            }
            catch (Exception ex)
            {
                return "Ett oväntat fel inträffade: " + ex.Message;
            }
        }




        public void AndraPodd(string gammaltNamn, string nyttNamn, string nyKategori)
        {
            var podd = poddRepository.HämtaAllaPoddar().FirstOrDefault(p => p.Namn == gammaltNamn);
            if (podd != null)
            {
                podd.Namn = nyttNamn;
                podd.Kategori = nyKategori;
                System.Diagnostics.Debug.WriteLine("Podd uppdaterad: " + podd.Namn);
                poddRepository.SaveChanges();
            }
        }

        public void UppdateraPodd(Podd uppdateradPodd)
        {
            var befintligPodd = poddRepository.HämtaAllaPoddar().FirstOrDefault(p => p.RSSLank == uppdateradPodd.RSSLank);
            if (befintligPodd != null)
            {
                befintligPodd.Namn = uppdateradPodd.Namn;
                befintligPodd.Kategori = uppdateradPodd.Kategori;
                poddRepository.SaveChanges(); 
            }
        }
    }
}