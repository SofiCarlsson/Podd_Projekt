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
        private int? valdKategoriId = null; 
        private Validering validering = new Validering(); 

        public Form1()
        {
            InitializeComponent();
            poddkontroll = new PoddController();
            kategoriController = new KategoriController();
            UppdateraPoddarListbox(poddkontroll.HämtaAllaPoddar());
            this.Load += new EventHandler(Form1_Load);
            UppdateraKategoriListbox();
            UppdateraPoddarListbox();
        }

        private void UppdateraPoddarListbox(List<Podd> poddar)
        {
            lbxMinaPoddar.Items.Clear();

            foreach (var podd in poddar) 
            {
                lbxMinaPoddar.Items.Add(podd); 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateComboBox(); 
        }

        private void UpdateComboBox()
        {
            cbxKategori.Items.Clear(); 
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

            string valideringsMeddelande = validering.NotEmpty(rss);
            if (!string.IsNullOrEmpty(valideringsMeddelande))
            {
                // Avbryt om valideringen misslyckas och skickar ett meddelande
                MessageBox.Show(valideringsMeddelande, "Valideringsfel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            await poddkontroll.HämtaPoddarRSSAsync(rss, string.IsNullOrEmpty(poddNamn) ? null : poddNamn, valdKategori);

            UppdateraPoddarListbox(poddkontroll.HämtaAllaPoddar());
        }

        private void UppdateraAvsnittListbox(Podd valdPodd)
        {
            lbxAvsnitt.Items.Clear(); 
            foreach (var avsnitt in valdPodd.AvsnittLista)
            {
                lbxAvsnitt.Items.Add(avsnitt.Namn);
            }

            // Välj automatiskt första avsnittet om det finns några avsnitt
            if (lbxAvsnitt.Items.Count > 0)
            {
                // Detta triggar SelectedIndexChanged
                lbxAvsnitt.SelectedIndex = 0; 
            }
            else
            {
                // Om ingen avsnittsbeskrivning finns ska detta skrivas ut istället
                tbxInfo.Text = "Ingen avsnittsbeskrivning tillgänglig.";
            }
        }

        private void UppdateraPoddarListbox()
        {
            lbxMinaPoddar.Items.Clear(); 

            foreach (var podd in poddkontroll.HämtaAllaPoddar()) 
            {
                lbxMinaPoddar.Items.Add(podd); 
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


            try
            {
                int nyttId = kategoriController.RetrieveAllKategorier().Count + 1;
                kategoriController.CreateKategori(nyttId, tbxKategori.Text);
                tbxKategori.Clear();
                UppdateraKategoriListbox();  
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
                Validering validering = new Validering();

                string errorMessage = validering.NotEmpty(tbxKategori.Text);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    return; 
                }

                try
                {
                    kategoriController.UpdateCategory(valdKategoriId.Value, tbxKategori.Text);
                    tbxKategori.Clear();
                    valdKategoriId = null; 
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
                // Hämta namnet på den valda kategorin för att visa i bekräftelsedialogen
                var valdKategori = (Kategori)lbxKategori.SelectedItem;
                string kategoriNamn = valdKategori.Namn;

                // Anropa NotEmpty för att validera att det finns en kategori vald
                string errorMessage = validering.NotEmpty(kategoriNamn);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    return; 
                }

                var result = MessageBox.Show(
                    $"Är du säker på att du vill ta bort kategorin '{kategoriNamn}'?",
                    "Bekräfta borttagning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        kategoriController.DeleteKategori(valdKategoriId.Value); 
                        tbxKategori.Clear(); 
                        valdKategoriId = null; 

                        UppdateraPoddarListbox(poddkontroll.HämtaAllaPoddar());
                        UppdateraKategoriListbox();
                        UpdateComboBox();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
                string nyKategori = cbxKategori.SelectedItem?.ToString();

                Validering validering = new Validering();

                string errorMessage = validering.NotEmpty(nyttNamn);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    return; 
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
                txbNamn.Text = valdPodd.Namn; 
                UppdateraAvsnittListbox(valdPodd); 
            }
        }


        private void lbxAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxAvsnitt.SelectedItem != null)
            {
                
                var valdPodd = (Podd)lbxMinaPoddar.SelectedItem;

                var valtAvsnittNamn = lbxAvsnitt.SelectedItem.ToString();
                var valtAvsnitt = valdPodd.AvsnittLista.FirstOrDefault(a => a.Namn == valtAvsnittNamn);

                string renBeskrivning = Regex.Replace(valtAvsnitt.AvsnittsBeskrivning, "<.*?>", string.Empty);

                if (valtAvsnitt != null)
                {
                    tbxInfo.Text = renBeskrivning; 
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
                UppdateraPoddarListbox(filtreradePoddar); 
            }
            else
            {
                UppdateraPoddarListbox(allaPoddar); 
            }
        }
    }
}
