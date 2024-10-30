using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Validering
    {
        public string NotEmpty(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "Fältet får inte vara tomt."; // Validering misslyckades, returnera felmeddelande
            }
            return string.Empty; // Ingen felmeddelande, validering lyckades
        }
    }
}
