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
            // Kontrollera att länken inte är tom
            string emptyCheck = NotEmpty(rssLank);
            if (!string.IsNullOrEmpty(emptyCheck))
            {
                return emptyCheck;
            }

            // Kontrollera att länken har ett korrekt format
            if (!Uri.IsWellFormedUriString(rssLank, UriKind.Absolute))
            {
                return "RSS-länken är inte giltig: länken har ett ogiltigt format.";
            }

            try
            {
                // Försök att skapa en XML-läsare för att verifiera att länken fungerar som ett RSS-flöde
                using (XmlReader reader = XmlReader.Create(rssLank))
                {
                    while (reader.Read()) { }  // Läs igenom flödet för att säkerställa att det är läsbart
                    return string.Empty;       // Om det lyckas, är länken giltig
                }
            }
            catch (XmlException)
            {
                return "RSS-länken är inte giltig: XML-strukturen är felaktig.";
            }
            catch (UriFormatException)
            {
                return "RSS-länken är inte giltig: ogiltigt URL-format.";
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
