using BLL;
<<<<<<< Updated upstream
=======
using Models;
>>>>>>> Stashed changes

namespace PoddarGrupp20
{
    public partial class Form1 : Form
    {
<<<<<<< Updated upstream
        private Poddkontrollerare poddkontroll;
=======
        private KategoriService kategoriService;
        private int? valdKategoriId = null; // H�ller koll p� vald kategori
>>>>>>> Stashed changes

        public Form1()
        {
            InitializeComponent();
<<<<<<< Updated upstream
            poddkontroll = new Poddkontrollerare();
        }

        private void btnS�k_Click(object sender, EventArgs e)
        {
            string rss = txtbRSS.Text;
            poddkontroll.H�mtaPoddarRSS(rss);
=======
            kategoriService = new KategoriService();
            UppdateraListbox();
        }

        private void UppdateraListbox()
        {
            lbxKategori.Items.Clear(); // Rensar listan f�rst
            foreach (var kategori in kategoriService.GetAllKategorier())
            {
                lbxKategori.Items.Add(kategori); // L�gg till kategorier i listboxen
            }
        }


        private void btnLaggTillKategori_Click(object sender, EventArgs e)
        {
            try
            {
                kategoriService.LaggTillKategori(tbxKategori.Text);
                tbxKategori.Clear();
                UppdateraListbox();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void lbxKategori_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lbxKategori.SelectedItem != null)
            {
                var valdKategori = (Kategori)lbxKategori.SelectedItem;
                tbxKategori.Text = valdKategori.Namn;
                valdKategoriId = valdKategori.Id;
            }
            else
            {
                valdKategoriId = null;
                MessageBox.Show("Ingen kategori vald.");
            }
        }

        private void btnAndraKategori_Click_1(object sender, EventArgs e)
        {
            if (valdKategoriId.HasValue)
            {
                try
                {
                    kategoriService.AndraKategori(valdKategoriId.Value, tbxKategori.Text);
                    tbxKategori.Clear();
                    valdKategoriId = null; // Nollst�ll vald kategori efter uppdatering
                    UppdateraListbox();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingen kategori vald att �ndra.");
            }
        }

        private void btnTaBortKategori_Click_1(object sender, EventArgs e)
        {
            if (valdKategoriId.HasValue)
            {
                DialogResult result = MessageBox.Show("Vill du verkligen ta bort den valda kategorin?", "Bekr�fta borttagning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    kategoriService.TaBortKategori(valdKategoriId.Value);
                    tbxKategori.Clear();
                    valdKategoriId = null; // Nollst�ll vald kategori efter borttagning
                    UppdateraListbox();
                }
            }
            else
            {
                MessageBox.Show("Ingen kategori vald att ta bort.");
            }
>>>>>>> Stashed changes
        }
    }

}
