namespace PoddarGrupp20
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSök = new Button();
            lblTitel = new Label();
            lbxMinaPoddar = new ListBox();
            txtbRSS = new TextBox();
            lblLank = new Label();
            lbxAvsnitt = new ListBox();
            btnAndra = new Button();
            btnTabort = new Button();
            cbxKategori = new ComboBox();
            lblKategori = new Label();
            btnAndraKategori = new Button();
            btnLaggTillKategori = new Button();
            btnTaBortKategori = new Button();
            lbxKategori = new ListBox();
            lblTitelPodd = new Label();
            txbNamn = new TextBox();
            lblNamngePodd = new Label();
            tbxKategori = new TextBox();
            lblPoddar = new Label();
            lblAvsnitt = new Label();
            lblInfo = new Label();
            btnFiltrera = new Button();
            tbxInfo = new TextBox();
            SuspendLayout();
            // 
            // btnSök
            // 
            btnSök.Location = new Point(23, 209);
            btnSök.Margin = new Padding(2, 2, 2, 2);
            btnSök.Name = "btnSök";
            btnSök.Size = new Size(118, 28);
            btnSök.TabIndex = 0;
            btnSök.Text = "Prenumerera";
            btnSök.UseVisualStyleBackColor = true;
            btnSök.Click += btnSök_Click;
            // 
            // lblTitel
            // 
            lblTitel.AutoSize = true;
            lblTitel.Location = new Point(434, 8);
            lblTitel.Margin = new Padding(2, 0, 2, 0);
            lblTitel.Name = "lblTitel";
            lblTitel.Size = new Size(0, 20);
            lblTitel.TabIndex = 1;
            // 
            // lbxMinaPoddar
            // 
            lbxMinaPoddar.FormattingEnabled = true;
            lbxMinaPoddar.Location = new Point(37, 266);
            lbxMinaPoddar.Margin = new Padding(2, 2, 2, 2);
            lbxMinaPoddar.Name = "lbxMinaPoddar";
            lbxMinaPoddar.Size = new Size(217, 244);
            lbxMinaPoddar.TabIndex = 2;
            lbxMinaPoddar.SelectedIndexChanged += lbxMinaPoddar_SelectedIndexChanged;
            // 
            // txtbRSS
            // 
            txtbRSS.Location = new Point(146, 79);
            txtbRSS.Margin = new Padding(2, 2, 2, 2);
            txtbRSS.Name = "txtbRSS";
            txtbRSS.Size = new Size(186, 27);
            txtbRSS.TabIndex = 3;
            // 
            // lblLank
            // 
            lblLank.AutoSize = true;
            lblLank.Location = new Point(18, 84);
            lblLank.Margin = new Padding(2, 0, 2, 0);
            lblLank.Name = "lblLank";
            lblLank.Size = new Size(126, 20);
            lblLank.TabIndex = 4;
            lblLank.Text = "Ange en RSS-länk";
            // 
            // lbxAvsnitt
            // 
            lbxAvsnitt.FormattingEnabled = true;
            lbxAvsnitt.Location = new Point(275, 266);
            lbxAvsnitt.Margin = new Padding(2, 2, 2, 2);
            lbxAvsnitt.Name = "lbxAvsnitt";
            lbxAvsnitt.Size = new Size(217, 244);
            lbxAvsnitt.TabIndex = 5;
            lbxAvsnitt.SelectedIndexChanged += lbxAvsnitt_SelectedIndexChanged;
            // 
            // btnAndra
            // 
            btnAndra.ForeColor = Color.Black;
            btnAndra.Location = new Point(163, 209);
            btnAndra.Margin = new Padding(2, 2, 2, 2);
            btnAndra.Name = "btnAndra";
            btnAndra.Size = new Size(90, 28);
            btnAndra.TabIndex = 7;
            btnAndra.Text = "Ändra";
            btnAndra.UseVisualStyleBackColor = true;
            btnAndra.Click += btnAndra_Click;
            // 
            // btnTabort
            // 
            btnTabort.Location = new Point(275, 209);
            btnTabort.Margin = new Padding(2, 2, 2, 2);
            btnTabort.Name = "btnTabort";
            btnTabort.Size = new Size(90, 28);
            btnTabort.TabIndex = 8;
            btnTabort.Text = "Ta bort";
            btnTabort.UseVisualStyleBackColor = true;
            btnTabort.Click += btnTabort_Click;
            // 
            // cbxKategori
            // 
            cbxKategori.FormattingEnabled = true;
            cbxKategori.Location = new Point(146, 171);
            cbxKategori.Margin = new Padding(2, 2, 2, 2);
            cbxKategori.Name = "cbxKategori";
            cbxKategori.Size = new Size(186, 28);
            cbxKategori.TabIndex = 9;
            cbxKategori.Text = "Välj Kategori";
            // 
            // lblKategori
            // 
            lblKategori.AutoSize = true;
            lblKategori.Location = new Point(707, 49);
            lblKategori.Margin = new Padding(2, 0, 2, 0);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(372, 20);
            lblKategori.TabIndex = 10;
            lblKategori.Text = "Här kan du lägga till/ ändra eller ta bort en ny kategori";
            // 
            // btnAndraKategori
            // 
            btnAndraKategori.Location = new Point(836, 119);
            btnAndraKategori.Margin = new Padding(2, 2, 2, 2);
            btnAndraKategori.Name = "btnAndraKategori";
            btnAndraKategori.Size = new Size(90, 28);
            btnAndraKategori.TabIndex = 11;
            btnAndraKategori.Text = "Ändra";
            btnAndraKategori.UseVisualStyleBackColor = true;
            btnAndraKategori.Click += btnAndraKategori_Click_1;
            // 
            // btnLaggTillKategori
            // 
            btnLaggTillKategori.Location = new Point(740, 119);
            btnLaggTillKategori.Margin = new Padding(2, 2, 2, 2);
            btnLaggTillKategori.Name = "btnLaggTillKategori";
            btnLaggTillKategori.Size = new Size(90, 28);
            btnLaggTillKategori.TabIndex = 12;
            btnLaggTillKategori.Text = "Lägg Till";
            btnLaggTillKategori.UseVisualStyleBackColor = true;
            btnLaggTillKategori.Click += btnLaggTillKategori_Click;
            // 
            // btnTaBortKategori
            // 
            btnTaBortKategori.Location = new Point(936, 119);
            btnTaBortKategori.Margin = new Padding(2, 2, 2, 2);
            btnTaBortKategori.Name = "btnTaBortKategori";
            btnTaBortKategori.Size = new Size(90, 28);
            btnTaBortKategori.TabIndex = 13;
            btnTaBortKategori.Text = "Ta Bort";
            btnTaBortKategori.UseVisualStyleBackColor = true;
            btnTaBortKategori.Click += btnTaBortKategori_Click_1;
            // 
            // lbxKategori
            // 
            lbxKategori.FormattingEnabled = true;
            lbxKategori.Location = new Point(777, 166);
            lbxKategori.Margin = new Padding(2, 2, 2, 2);
            lbxKategori.Name = "lbxKategori";
            lbxKategori.Size = new Size(217, 344);
            lbxKategori.TabIndex = 14;
            lbxKategori.SelectedIndexChanged += lbxKategori_SelectedIndexChanged_1;
            // 
            // lblTitelPodd
            // 
            lblTitelPodd.AutoSize = true;
            lblTitelPodd.Font = new Font("Segoe UI", 14F);
            lblTitelPodd.Location = new Point(399, 8);
            lblTitelPodd.Margin = new Padding(2, 0, 2, 0);
            lblTitelPodd.Name = "lblTitelPodd";
            lblTitelPodd.Size = new Size(189, 32);
            lblTitelPodd.TabIndex = 17;
            lblTitelPodd.Text = "PoddApplikation";
            // 
            // txbNamn
            // 
            txbNamn.Location = new Point(146, 131);
            txbNamn.Margin = new Padding(2, 2, 2, 2);
            txbNamn.Name = "txbNamn";
            txbNamn.Size = new Size(186, 27);
            txbNamn.TabIndex = 18;
            // 
            // lblNamngePodd
            // 
            lblNamngePodd.AutoSize = true;
            lblNamngePodd.Location = new Point(26, 131);
            lblNamngePodd.Margin = new Padding(2, 0, 2, 0);
            lblNamngePodd.Name = "lblNamngePodd";
            lblNamngePodd.Size = new Size(104, 20);
            lblNamngePodd.TabIndex = 19;
            lblNamngePodd.Text = "Namnge Podd";
            // 
            // tbxKategori
            // 
            tbxKategori.Location = new Point(777, 79);
            tbxKategori.Margin = new Padding(2, 2, 2, 2);
            tbxKategori.Name = "tbxKategori";
            tbxKategori.Size = new Size(217, 27);
            tbxKategori.TabIndex = 20;
            // 
            // lblPoddar
            // 
            lblPoddar.AutoSize = true;
            lblPoddar.Location = new Point(94, 243);
            lblPoddar.Margin = new Padding(2, 0, 2, 0);
            lblPoddar.Name = "lblPoddar";
            lblPoddar.Size = new Size(56, 20);
            lblPoddar.TabIndex = 21;
            lblPoddar.Text = "Poddar";
            // 
            // lblAvsnitt
            // 
            lblAvsnitt.AutoSize = true;
            lblAvsnitt.Location = new Point(344, 239);
            lblAvsnitt.Margin = new Padding(2, 0, 2, 0);
            lblAvsnitt.Name = "lblAvsnitt";
            lblAvsnitt.Size = new Size(54, 20);
            lblAvsnitt.TabIndex = 22;
            lblAvsnitt.Text = "Avsnitt";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(546, 239);
            lblInfo.Margin = new Padding(2, 0, 2, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(86, 20);
            lblInfo.TabIndex = 23;
            lblInfo.Text = "Avsnittsinfo";
            // 
            // btnFiltrera
            // 
            btnFiltrera.Location = new Point(364, 171);
            btnFiltrera.Margin = new Padding(2, 2, 2, 2);
            btnFiltrera.Name = "btnFiltrera";
            btnFiltrera.Size = new Size(90, 28);
            btnFiltrera.TabIndex = 24;
            btnFiltrera.Text = "Filtrera";
            btnFiltrera.UseVisualStyleBackColor = true;
            btnFiltrera.Click += btnFiltrera_Click;
            // 
            // tbxInfo
            // 
            tbxInfo.Location = new Point(530, 266);
            tbxInfo.Margin = new Padding(2, 2, 2, 2);
            tbxInfo.Multiline = true;
            tbxInfo.Name = "tbxInfo";
            tbxInfo.ScrollBars = ScrollBars.Vertical;
            tbxInfo.Size = new Size(213, 244);
            tbxInfo.TabIndex = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 531);
            Controls.Add(tbxInfo);
            Controls.Add(btnFiltrera);
            Controls.Add(lblInfo);
            Controls.Add(lblAvsnitt);
            Controls.Add(lblPoddar);
            Controls.Add(tbxKategori);
            Controls.Add(lblNamngePodd);
            Controls.Add(txbNamn);
            Controls.Add(lblTitelPodd);
            Controls.Add(lbxKategori);
            Controls.Add(btnTaBortKategori);
            Controls.Add(btnLaggTillKategori);
            Controls.Add(btnAndraKategori);
            Controls.Add(lblKategori);
            Controls.Add(cbxKategori);
            Controls.Add(btnTabort);
            Controls.Add(btnAndra);
            Controls.Add(lbxAvsnitt);
            Controls.Add(lblLank);
            Controls.Add(txtbRSS);
            Controls.Add(lbxMinaPoddar);
            Controls.Add(lblTitel);
            Controls.Add(btnSök);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSök;
        private Label lblTitel;
        private ListBox lbxMinaPoddar;
        private TextBox txtbRSS;
        private Label lblLank;
        private ListBox lbxAvsnitt;
        private Button btnAndra;
        private Button btnTabort;
        private ComboBox cbxKategori;
        private Label lblKategori;
        private Button btnAndraKategori;
        private Button btnLaggTillKategori;
        private Button btnTaBortKategori;
        private ListBox lbxKategori;
        private Label lblTitelPodd;
        private TextBox txbNamn;
        private Label lblNamngePodd;
        private TextBox tbxKategori;
        private Label lblPoddar;
        private Label lblAvsnitt;
        private Label lblInfo;
        private Button btnFiltrera;
        private TextBox tbxInfo;
    }
}
