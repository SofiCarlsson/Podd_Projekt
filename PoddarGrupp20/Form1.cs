using BLL;
using Models;

namespace PoddarGrupp20
{
    public partial class Form1 : Form
    {
        private PoddController poddkontroll;
        private KategoriController kategoriController;
        private int? valdKategoriId = null; // H�ller koll p� vald kategori

        public Form1()
        {
            InitializeComponent();
            poddkontroll = new PoddController();
            kategoriController = new KategoriController();
            UppdateraListbox();
            this.Load += new EventHandler(Form1_Load);
        }

        private void UppdateraListbox()
        {
            lbxKategori.Items.Clear(); // Rensar listan f�rst
            foreach (var kategori in kategoriController.GetAllKategorier())
            {
                lbxKategori.Items.Add(kategori); // L�gg till kategorier i listboxen
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

        private void btnS�k_Click(object sender, EventArgs e)
        {
            string rss = txtbRSS.Text;
            string poddNamn = txbNamn.Text;
            string valdKategori = cbxKategori.SelectedItem?.ToString();

            poddkontroll.H�mtaPoddarRSS(rss, string.IsNullOrEmpty(poddNamn) ? null : poddNamn, valdKategori);

            // Uppdatera ListBox med poddar
            UppdateraPoddarListbox();
        }

        // Metoden f�r att uppdatera ListBox med poddar
        private void UppdateraAvsnittListbox()
        {
            lbxMinaPoddar.Items.Clear(); // T�m listboxen f�rst
            List<Podd> poddar = poddkontroll.H�mtaAllaPoddar(); // H�mta alla poddar fr�n BLL

            // L�gg till rubriker i ListBox
            foreach (var podd in poddar)
            {
                lbxAvsnitt.Items.Add(podd.Avsnitt); // Visa bara avsnittsnamnen 
            }
        }

        private void UppdateraPoddarListbox()
{
    List<Podd> allaPoddar = poddkontroll.H�mtaAllaPoddar(); // H�mta alla poddar
    UppdateraPoddarListbox(allaPoddar); // Skicka med alla poddar
}

        private void UppdateraPoddarListbox(List<Podd> poddar)
        {
            lbxMinaPoddar.Items.Clear(); // T�m listboxen f�rst

            foreach (var podd in poddar)
            {
                if (!lbxMinaPoddar.Items.Contains(podd.Namn))
                {
                    lbxMinaPoddar.Items.Add(podd.Namn);
                }
            }
        }


        private void btnLaggTillKategori_Click(object sender, EventArgs e)
        {
            try
            {
                kategoriController.LaggTillKategori(tbxKategori.Text);
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
                    kategoriController.AndraKategori(valdKategoriId.Value, tbxKategori.Text);
                    tbxKategori.Clear();
                    valdKategoriId = null; // Nollst�ll vald kategori efter uppdatering
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
                    kategoriController.TaBortKategori(valdKategoriId.Value);
                    tbxKategori.Clear();
                    valdKategoriId = null; // Nollst�ll vald kategori efter borttagning
                    UppdateraListbox();
                    UpdateComboBox();
                }
            }
            else
            {
                MessageBox.Show("Ingen kategori vald att ta bort.");
            }
        }

        private void btnAndra_Click(object sender, EventArgs e)
        {
            if (lbxMinaPoddar.SelectedItem != null)
            {
                string nyttNamn = txbNamn.Text;
                string nyKategori = cbxKategori.SelectedItem?.ToString(); // Ny kategori

                poddkontroll.AndraPodd(lbxMinaPoddar.SelectedItem.ToString(), nyttNamn, nyKategori);

                UppdateraPoddarListbox();
            }
            else
            {
                MessageBox.Show("Ingen podd vald.");
            }
        }

        private void btnTabort_Click(object sender, EventArgs e)
        {
            if (lbxMinaPoddar.SelectedItem != null)
            {
                string valtPoddNamn = lbxMinaPoddar.SelectedItem.ToString();

                // H�mta poddens RSS-l�nk baserat p� det valda namnet
                Podd valdPodd = poddkontroll.H�mtaAllaPoddar().FirstOrDefault(p => p.Namn == valtPoddNamn);
                if (valdPodd != null)
                {
                    DialogResult result = MessageBox.Show("Vill du verkligen ta bort den valda podden?", "Bekr�fta borttagning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        poddkontroll.TaBortPodd(valdPodd.RSSLank);
                        UppdateraPoddarListbox();
                        MessageBox.Show("Podden har tagits bort.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingen podd vald att ta bort.");
            }
        }

        private void btnFiltrera_Click(object sender, EventArgs e)
        {
            string valdKategori = cbxKategori.SelectedItem?.ToString();
            List<Podd> allaPoddar = poddkontroll.H�mtaAllaPoddar();

            if (!string.IsNullOrEmpty(valdKategori))
            {
                var filtreradePoddar = allaPoddar.Where(p => p.Kategori == valdKategori).ToList();
                UppdateraPoddarListbox(filtreradePoddar); // Uppdatera listbox med filtrerade poddar
            }
            else
            {
                UppdateraPoddarListbox(allaPoddar); // Visa alla poddar om ingen kategori �r vald
            }
        }
    }

}
