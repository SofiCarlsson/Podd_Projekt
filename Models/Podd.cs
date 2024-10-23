namespace Models
{
    public class Podd
    {
        public string Id { get; set; } //en URL i RSS-floden faktiskt 
        public string Rubrik { get; set; }
        public DateTimeOffset Publiceringsdatum { get; set; }


        public Podd()
        {

        }

        public Podd(string id, string rubrik, DateTimeOffset publiceringsdatum, string innehall)
        {
            Id = id;
            Rubrik = rubrik;
            Publiceringsdatum = publiceringsdatum;
        }

    }
}
