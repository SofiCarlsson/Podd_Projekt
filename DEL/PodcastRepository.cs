using Models;

namespace DEL
{
    public class PodcastRepository
    {
        private List<Podd> poddLista = new List<Podd>();

        public void LäggTillPodd(Podd podden)
        {
            if (!poddLista.Any(p => p.RSSLank == podden.RSSLank))
            {
                poddLista.Add(podden);
            }
        }

        public List<Podd> HämtaAllaPoddar()
        {
            return poddLista;
        }
    }
}
