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
        // Privat lista över befintliga kategorinamn
        private List<string> kategorier = new List<string>();

        // Metod för att kontrollera att en sträng inte är tom eller bara innehåller vita tecken
        public string NotEmpty(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "Fältet får inte vara tomt."; // Validering misslyckades, returnera felmeddelande
            }
            return string.Empty; // Ingen felmeddelande, validering lyckades
        }

        // Metod för att verifiera att RSS-länken är giltig
        public string VerifieraRSSLank(string rssLank)
        {
            string emptyCheck = NotEmpty(rssLank);
            if (!string.IsNullOrEmpty(emptyCheck))
            {
                return emptyCheck; // Returnera felmeddelande om länken är tom
            }

            if (!Uri.IsWellFormedUriString(rssLank, UriKind.Absolute))
            {
                return "RSS-länken är inte giltig: länken har ett ogiltigt format.";
            }

            try
            {
                using (XmlReader.Create(rssLank))
                {
                    return string.Empty; // Länken är giltig
                }
            }
            catch (Exception)
            {
                return "RSS-länken är inte giltig: kunde inte läsa in flödet.";
            }
        }
    }
}
