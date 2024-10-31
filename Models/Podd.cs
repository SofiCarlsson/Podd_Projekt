namespace Models
{
    public class Podd
    {
        public string Namn { get; set; }
        public string RSSLank { get; set; }
        public List<string> Avsnitt { get; set; } // Ändra till lista
        public string Kategori { get; set; }
        public Dictionary<string, string> AvsnittBeskrivningar { get; set; } = new Dictionary<string, string>();

        public Podd()
        {
            Avsnitt = new List<string>(); // Initiera listan i konstruktorn

        }

        public override string ToString()
        {
            return Namn; // Returnera namnet istället för hela objektet
        }
    }


}
