using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Models
{
    public class Validering
    {
        private List<string> kategorier = new List<string>();

        public string NotEmpty(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "Fältet får inte vara tomt.";
            }
            return string.Empty;
        }

        public string VerifieraRSSLank(string rssLank)
        {
            string emptyCheck = NotEmpty(rssLank);
            if (!string.IsNullOrEmpty(emptyCheck))
            {
                return emptyCheck;
            }

            if (!Uri.IsWellFormedUriString(rssLank, UriKind.Absolute))
            {
                return "RSS-länken är inte giltig: länken har ett ogiltigt format.";
            }

            try
            {
                using (XmlReader.Create(rssLank))
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return "RSS-länken är inte giltig: kunde inte läsa in flödet.";
            }
        }

        // Överlagrad metod för att validera unika ID:n
        public string ValideraUnikKategori(List<Kategori> kategorier, int id)
        {
            if (kategorier.Any(k => k.Id == id))
            {
                return "En kategori med detta ID finns redan.";
            }
            return string.Empty;
        }

        // Överlagrad metod för att validera unika namn
        public string ValideraUnikKategori(List<Kategori> kategorier, string namn)
        {
            if (kategorier.Any(k => k.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase)))
            {
                return "En kategori med detta namn finns redan.";
            }
            return string.Empty;
        }
    }
}
