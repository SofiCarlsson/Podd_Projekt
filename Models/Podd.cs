﻿namespace Models
{
    public class Podd
    {
      
        public string Avsnitt { get; set; }

        public string Namn { get; set; }
        public string RSSLank { get; set; }
        

        public Podd()
        {

        }

        public Podd(string avsnitt, string namn, string rsslank)
        {
           Avsnitt = avsnitt;
            Namn = namn;
            RSSLank = rsslank;
        }

    }
}
