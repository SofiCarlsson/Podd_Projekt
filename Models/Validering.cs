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
            // Använd befintlig metod för att kontrollera att länken inte är tom
            string emptyCheck = NotEmpty(rssLank);
            if (!string.IsNullOrEmpty(emptyCheck))
            {
                return emptyCheck; // Returnera felmeddelande om länken är tom
            }

            // Kontrollera om RSS-länken har ett giltigt URL-format
            //UriKind är en enumerering i C# som har tre värden
            //Absolute betyder att den innehåller (t.ex. http://, https://
            if (!Uri.IsWellFormedUriString(rssLank, UriKind.Absolute))
            {
                return "RSS-länken är inte giltig: länken har ett ogiltigt format.";
            }

            // Försök att läsa in RSS-flödet för att säkerställa giltighet
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