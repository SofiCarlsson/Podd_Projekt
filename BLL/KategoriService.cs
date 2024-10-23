using DEL;
using Models;

namespace BLL
{
    public class KategoriService
    {
        private KategoriRepository kategoriRepository;

        public KategoriService()
        {
            kategoriRepository = new KategoriRepository();
        }

        public List<Kategori> GetAllKategorier()
        {
            return kategoriRepository.GetAll();
        }

        public void LaggTillKategori(string namn)
        {
            if (string.IsNullOrWhiteSpace(namn))
            {
                throw new ArgumentException("Kategorinamnet kan inte vara tomt.");
            }

            // Kontrollera om kategorin redan finns
            if (kategoriRepository.GetAll().Any(k => k.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("En kategori med detta namn finns redan.");
            }

            // Om ingen dubblett hittas, lägg till kategorin
            int nyttId = kategoriRepository.GetAll().Count + 1; // Simulera Id
            var nyKategori = new Kategori(nyttId, namn);
            kategoriRepository.Add(nyKategori);
        }

        public void AndraKategori(int id, string nyttNamn)
        {
            if (string.IsNullOrWhiteSpace(nyttNamn))
            {
                throw new ArgumentException("Nytt namn kan inte vara tomt.");
            }

            // Kontrollera om det nya namnet redan finns, men med ett annat Id
            if (kategoriRepository.GetAll().Any(k => k.Namn.Equals(nyttNamn, StringComparison.OrdinalIgnoreCase) && k.Id != id))
            {
                throw new ArgumentException("En kategori med detta namn finns redan.");
            }

            // Om ingen dubblett hittas, uppdatera kategorin
            kategoriRepository.Update(id, nyttNamn);
        }

        public void TaBortKategori(int id)
        {
            kategoriRepository.Remove(id);
        }
    }

}
