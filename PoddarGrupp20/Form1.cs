using BLL;
using Models;

namespace PoddarGrupp20
{
    public partial class Form1 : Form
    {
        private Poddkontrollerare poddkontroll;
        private KategoriService kategoriService;
        private int? valdKategoriId = null; // Håller koll på vald kategori

        public Form1()
        {
            InitializeComponent();
            poddkontroll = new Poddkontrollerare();
            kategoriService = new KategoriService();
            UppdateraListbox();
            this.Load += new EventHandler(Form1_Load);
        }

        private void UppdateraListbox()
        {
            lbxKategori.Items.Clear(); // Rensar listan först
            foreach (var kategori in kategoriService.GetAllKategorier())
            {
                lbxKategori.Items.Add(kategori); // Lägg till kategorier i listboxen
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateComboBox(); // Fyll ComboBox initialt
        }

        private void UpdateComboBox()
        {
            cbxKategori.Items.Clear(); // Rensa befintliga element
            foreach (var item in lbxKategori.Items)
            {
                cbxKategori.Items.Add(item);
            }
        }

        private void btnSök_Click(object sender, EventArgs e)
        {
            string rss = txtbRSS.Text;
            poddkontroll.HämtaPoddarRSS(rss);
        }


        private void btnLaggTillKategori_Click(object sender, EventArgs e)
        {
            try
            {
                kategoriService.LaggTillKategori(tbxKategori.Text);
                tbxKategori.Clear();
                UppdateraListbox();
                UpdateComboBox();
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
                    valdKategoriId = null; // Nollställ vald kategori efter uppdatering
                    UppdateraListbox();
                    UpdateComboBox();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingen kategori vald att ändra.");
            }
        }

        private void btnTaBortKategori_Click_1(object sender, EventArgs e)
        {
            if (valdKategoriId.HasValue)
            {
                DialogResult result = MessageBox.Show("Vill du verkligen ta bort den valda kategorin?", "Bekräfta borttagning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    kategoriService.TaBortKategori(valdKategoriId.Value);
                    tbxKategori.Clear();
                    valdKategoriId = null; // Nollställ vald kategori efter borttagning
                    UppdateraListbox();
                    UpdateComboBox();
                }
            }
            else
            {
                MessageBox.Show("Ingen kategori vald att ta bort.");
            }
        }
    }

}
