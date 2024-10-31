using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Namn { get; set; }

        // Parameterlös konstruktor för serialisering
        public Kategori() { }

        // Konstruktor med parametrar
        public Kategori(int id, string namn)
        {
            Id = id;
            Namn = namn;
        }

        public override string ToString()
        {
            return Namn; // Detta gör att Namn visas i listboxen
        }
    }
}
