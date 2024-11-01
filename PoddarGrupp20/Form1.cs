using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PoddarGrupp20
{
    public partial class Form1 : Form
    {
        private PoddController poddkontroll;
        private KategoriController kategoriController;
        private int? valdKategoriId = null; // Håller koll på vald kategori
        private Validering validering = new Validering(); // Skapa en instans av Validering

        public Form1()
        {
            InitializeComponent();
            poddkontroll = new PoddController();
            kategoriController = new KategoriController();
            UppdateraPoddarListbox(poddkontroll.HämtaAllaPoddar()); // Skicka in alla poddar
            this.Load += new EventHandler(Form1_Load);
            UppdateraKategoriListbox();
            UppdateraPoddarListbox();
        }

        private void UppdateraPoddarListbox(List<Podd> poddar)
        {
            lbxMinaPoddar.Items.Clear(); // Töm listboxen först

            foreach (var podd in poddar) // Hämta alla poddar
            {
                lbxMinaPoddar.Items.Add(podd); // Lägg till hela poddobjektet
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

        private async void btnSök_Click(object sender, EventArgs e)
        {
            string rss = txtbRSS.Text;
            string poddNamn = txbNamn.Text;
            string valdKategori = cbxKategori.SelectedItem?.ToString();

            // Kontrollera att RSS-länken inte är tom
            string valideringsMeddelande = validering.NotEmpty(rss);
            if (!string.IsNullOrEmpty(valideringsMeddelande))
            {
                MessageBox.Show(valideringsMeddelande, "Valideringsfel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Avbryt om valideringen misslyckas
            }

            // Anropa den asynkrona metoden för att hämta poddar
            await poddkontroll.HämtaPoddarRSSAsync(rss, string.IsNullOrEmpty(poddNamn) ? null : poddNamn, valdKategori);

            // Uppdatera ListBox med poddar
            UppdateraPoddarListbox(poddkontroll.HämtaAllaPoddar());
        }

        // Metoden för att uppdatera ListBox med poddar
        private void UppdateraAvsnittListbox(Podd valdPodd)
        {
            lbxAvsnitt.Items.Clear(); // Töm listboxen först
            foreach (var avsnitt in valdPodd.AvsnittLista)
            {
                lbxAvsnitt.Items.Add(avsnitt.Namn);
            }

            // Välj automatiskt första avsnittet om det finns några avsnitt
            if (lbxAvsnitt.Items.Count > 0)
            {
                lbxAvsnitt.SelectedIndex = 0; // Detta triggar SelectedIndexChanged och visar beskrivningen
            }
            else
            {
                // Om inga avsnitt finns, rensa beskrivningen
                tbxInfo.Text = "Ingen avsnittsbeskrivning tillgänglig.";
            }
        }

        private void UppdateraPoddarListbox()
        {
            lbxMinaPoddar.Items.Clear(); // Töm listboxen först

            foreach (var podd in poddkontroll.HämtaAllaPoddar()) // Hämta alla poddar
            {
                lbxMinaPoddar.Items.Add(podd); // Lägg till hela poddobjektet
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

                // Anropa NotEmpty för att validera inputen
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
                    valdKategoriId = null; // Nollställ vald kategori efter uppdatering
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
                MessageBox.Show("Ingen kategori vald att ändra.");
            }
        }

        private void btnTaBortKategori_Click_1(object sender, EventArgs e)
        {
            if (valdKategoriId.HasValue)
            {
                Validering validering = new Validering();

                // Anropa NotEmpty för att validera inputen
                string errorMessage = validering.NotEmpty(tbxKategori.Text);

                // Kolla om det finns ett felmeddelande
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    return; // Avbryt om valideringen misslyckas
                }

                try
                {
                    kategoriController.DeleteKategori(valdKategoriId.Value); // Ändrat här för att ta bort kategorin
                    tbxKategori.Clear();
                    valdKategoriId = null; // Nollställ vald kategori efter borttagning
                    UppdateraPoddarListbox(poddkontroll.HämtaAllaPoddar());
                    UpdateComboBox();
                    UppdateraKategoriListbox(); // Lägg till detta för att uppdatera lbxKategori
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
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
                    return; // Avbryt om valideringen misslyckas
                }

                poddkontroll.AndraPodd(valtPoddNamn, nyttNamn, nyKategori);
                UppdateraPoddarListbox(poddkontroll.HämtaAllaPoddar());
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

                var valdPodd = (Podd)lbxMinaPoddar.SelectedItem;

                 DialogResult result = MessageBox.Show("Vill du verkligen ta bort den valda podden?", "Bekräfta borttagning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        poddkontroll.TaBortPodd(valdPodd.RSSLank);
                        UppdateraPoddarListbox(poddkontroll.HämtaAllaPoddar());
                    }
                }
            
            else
            {
                MessageBox.Show("Ingen podd vald.");
            }
        }



        private void lbxMinaPoddar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxMinaPoddar.SelectedItem != null)
            {
                var valdPodd = (Podd)lbxMinaPoddar.SelectedItem;
                txbNamn.Text = valdPodd.Namn; // Visa vald podds namn i textbox
                UppdateraAvsnittListbox(valdPodd); // Hämta avsnitt från vald podd
            }
        }


        private void lbxAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxAvsnitt.SelectedItem != null)
            {
                
                var valdPodd = (Podd)lbxMinaPoddar.SelectedItem;

                var valtAvsnittNamn = lbxAvsnitt.SelectedItem.ToString();
                var valtAvsnitt = valdPodd.AvsnittLista.FirstOrDefault(a => a.Namn == valtAvsnittNamn);

                if (valtAvsnitt != null)
                {
                    tbxInfo.Text = valtAvsnitt.AvsnittsBeskrivning; // Visa avsnittets beskrivning
                }
                else
                {
                    tbxInfo.Text = "Ingen beskrivning tillgänglig.";
                }
            }
        }

        private void btnFiltrera_Click(object sender, EventArgs e)
        {
            string valdKategori = cbxKategori.SelectedItem?.ToString();
            List<Podd> allaPoddar = poddkontroll.HämtaAllaPoddar();

            if (!string.IsNullOrEmpty(valdKategori))
            {
                var filtreradePoddar = allaPoddar.Where(p => p.Kategori == valdKategori).ToList();
                UppdateraPoddarListbox(filtreradePoddar); // Uppdatera listbox med filtrerade poddar
            }
            else
            {
                UppdateraPoddarListbox(allaPoddar); // Visa alla poddar om ingen kategori är vald
            }
        }
    }
}
