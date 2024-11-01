using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
       
    public class Avsnitt
    {
        public string Namn { get; set; }
        public string AvsnittsBeskrivning {  get; set; }

        public Avsnitt() { }

        public Avsnitt(string namn, string avsnittsBeskrivning)
        {
            Namn = namn;
            AvsnittsBeskrivning = avsnittsBeskrivning;
        }
    }
}
