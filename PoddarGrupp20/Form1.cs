using BLL;
using Models;
using System.Globalization;
using System.Text.RegularExpressions;


namespace PoddarGrupp20
{
    public partial class Form1 : Form
    {
        private PoddController poddkontroll;
        private KategoriController kategoriController;
        private int? valdKategoriId = null; // H�ller koll p� vald kategori
        private Validering validering = new Validering(); // Skapa en instans av Validering


        public Form1()
        {
            InitializeComponent();
            poddkontroll = new PoddController();
            kategoriController = new KategoriController();
            UppdateraPoddarListbox(poddkontroll.H�mtaAllaPoddar()); // Skicka in alla poddar
            this.Load += new EventHandler(Form1_Load);
        }

        private void UppdateraPoddarListbox(List<Podd> poddar)
        {
            lbxMinaPoddar.Items.Clear(); // T�m listboxen f�rst

            foreach (var podd in poddar) // H�mta alla poddar
            {
                lbxMinaPoddar.Items.Add(podd); // L�gg till hela poddobjektet
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

        private async void btnS�k_Click(object sender, EventArgs e)
        {
            string rss = txtbRSS.Text;
            string poddNamn = txbNamn.Text;
            string valdKategori = cbxKategori.SelectedItem?.ToString();

            // Kontrollera att RSS-l�nken inte �r tom
            string valideringsMeddelande = validering.NotEmpty(rss);
            if (!string.IsNullOrEmpty(valideringsMeddelande))
            {
                MessageBox.Show(valideringsMeddelande, "Valideringsfel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Avbryt om valideringen misslyckas
            }

            // Anropa den asynkrona metoden f�r att h�mta poddar
            await poddkontroll.H�mtaPoddarRSSAsync(rss, string.IsNullOrEmpty(poddNamn) ? null : poddNamn, valdKategori);

            // Uppdatera ListBox med poddar
            UppdateraPoddarListbox(poddkontroll.H�mtaAllaPoddar());
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
            lbxMinaPoddar.Items.Clear(); // T�m listboxen f�rst

            foreach (var podd in poddkontroll.H�mtaAllaPoddar()) // H�mta alla poddar
            {
                lbxMinaPoddar.Items.Add(podd); // L�gg till hela poddobjektet
            }
        }



        private void btnLaggTillKategori_Click(object sender, EventArgs e)
        {
            string valideringsMeddelande = validering.ValideraOchLaggTillKategori(tbxKategori.Text);
            if (!string.IsNullOrEmpty(valideringsMeddelande))
            {
                MessageBox.Show(valideringsMeddelande, "Valideringsfel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int nyttId = kategoriController.RetrieveAllKategorier().Count + 1;
                kategoriController.CreateKategori(nyttId, tbxKategori.Text);
                tbxKategori.Clear();
                UppdateraKategoriListbox();  // Uppdaterar lbxKategori
                UpdateComboBox();  // Uppdaterar ComboBox
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
                Validering validering = new Validering();

                // Anropa NotEmpty f�r att validera inputen
                string errorMessage = validering.NotEmpty(tbxKategori.Text);

                // Kolla om det finns ett felmeddelande
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    return; // Avbryt om valideringen misslyckades
                }

                try
                {
                    kategoriController.UpdateCategory(valdKategoriId.Value, tbxKategori.Text);
                    tbxKategori.Clear();
                    valdKategoriId = null; // Nollst�ll vald kategori efter uppdatering
                    UppdateraKategoriListbox();
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
                Validering validering = new Validering();

                // Anropa NotEmpty f�r att validera inputen
                string errorMessage = validering.NotEmpty(tbxKategori.Text);

                // Kolla om det finns ett felmeddelande
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    return; // Avbryt om valideringen misslyckas
                }

                try
                {
                    kategoriController.UpdateCategory(valdKategoriId.Value, tbxKategori.Text);
                    tbxKategori.Clear();
                    valdKategoriId = null; // Nollst�ll vald kategori efter uppdatering
                    UppdateraPoddarListbox(poddkontroll.H�mtaAllaPoddar());
                    UpdateComboBox();
                    UppdateraKategoriListbox(); // L�gg till detta f�r att uppdatera lbxKategori
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


        private void btnAndra_Click(object sender, EventArgs e)
        {
            if (lbxMinaPoddar.SelectedItem != null)
            {
                string valtPoddNamn = lbxMinaPoddar.SelectedItem.ToString();
                string nyttNamn = txbNamn.Text;
                string nyKategori = cbxKategori.SelectedItem?.ToString(); // Ny kategori

                // Skapa en instans av Validering
                Validering validering = new Validering();

                // Anropa NotEmpty och spara resultatet
                string errorMessage = validering.NotEmpty(nyttNamn);

                // Kolla om det finns ett felmeddelande
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    // Visa felmeddelandet
                    MessageBox.Show(errorMessage);
                    return; // Avbryt om valideringen misslyckades
                }

                poddkontroll.AndraPodd(valtPoddNamn, nyttNamn, nyKategori);
                UppdateraPoddarListbox(poddkontroll.H�mtaAllaPoddar());
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

        public void VisaAvsnitt(Podd valdPodd)
        {
            lbxAvsnitt.Items.Clear(); // T�m ListBoxen innan du l�gger till nya avsnitt

            foreach (string avsnitt in valdPodd.Avsnitt)
            {
                lbxAvsnitt.Items.Add(avsnitt); // L�gg till varje avsnitt i ListBox
            }
        }


        private void lbxMinaPoddar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxMinaPoddar.SelectedItem is Podd valdPodd) // Kontrollera att valdPodd �r av typen Podd
            {
                VisaAvsnitt(valdPodd); // Visa avsnitt f�r vald podd
            }
        }

        private void UppdateraKategoriListbox()
        {
            lbxKategori.Items.Clear();
            var kategorier = kategoriController.RetrieveAllKategorier();
            foreach (var kategori in kategorier)
            {
                lbxKategori.Items.Add(kategori);
            }
        }


        private void lbxAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxAvsnitt.SelectedItem != null && lbxMinaPoddar.SelectedItem != null)
            {
                string valtPoddNamn = lbxMinaPoddar.SelectedItem.ToString();
                string valtAvsnittNamn = lbxAvsnitt.SelectedItem.ToString();

                // H�mta podd och dess avsnitt
                Podd valdPodd = poddkontroll.H�mtaAllaPoddar().FirstOrDefault(p => p.Namn == valtPoddNamn);

                if (valdPodd != null && valdPodd.Avsnitt.Contains(valtAvsnittNamn))
                {
                    // L�gg till avsnittsbeskrivningen och ta bort HTML-taggar
                    string beskrivning = valdPodd.AvsnittBeskrivningar.ContainsKey(valtAvsnittNamn)
                        ? valdPodd.AvsnittBeskrivningar[valtAvsnittNamn]
                        : "Ingen beskrivning tillg�nglig";

                    // Ta bort HTML-taggar med regex
                    string renBeskrivning = Regex.Replace(beskrivning, "<.*?>", string.Empty);

                    tbxInfo.Text = "Beskrivning: " + renBeskrivning;
                }
            }
        }

    }

}
