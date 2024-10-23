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
            lbxInfo = new ListBox();
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
            SuspendLayout();
            // 
            // btnSök
            // 
            btnSök.Location = new Point(38, 335);
            btnSök.Margin = new Padding(4, 4, 4, 4);
            btnSök.Name = "btnSök";
            btnSök.Size = new Size(191, 44);
            btnSök.TabIndex = 0;
            btnSök.Text = "Prenumerera";
            btnSök.UseVisualStyleBackColor = true;
            btnSök.Click += btnSök_Click;
            // 
            // lblTitel
            // 
            lblTitel.AutoSize = true;
            lblTitel.Location = new Point(705, 12);
            lblTitel.Margin = new Padding(4, 0, 4, 0);
            lblTitel.Name = "lblTitel";
            lblTitel.Size = new Size(0, 32);
            lblTitel.TabIndex = 1;
            // 
            // lbxMinaPoddar
            // 
            lbxMinaPoddar.FormattingEnabled = true;
            lbxMinaPoddar.Location = new Point(60, 425);
            lbxMinaPoddar.Margin = new Padding(4, 4, 4, 4);
            lbxMinaPoddar.Name = "lbxMinaPoddar";
            lbxMinaPoddar.Size = new Size(350, 388);
            lbxMinaPoddar.TabIndex = 2;
            // 
            // txtbRSS
            // 
            txtbRSS.Location = new Point(237, 127);
            txtbRSS.Margin = new Padding(4, 4, 4, 4);
            txtbRSS.Name = "txtbRSS";
            txtbRSS.Size = new Size(300, 39);
            txtbRSS.TabIndex = 3;
            // 
            // lblLank
            // 
            lblLank.AutoSize = true;
            lblLank.Location = new Point(30, 134);
            lblLank.Margin = new Padding(4, 0, 4, 0);
            lblLank.Name = "lblLank";
            lblLank.Size = new Size(205, 32);
            lblLank.TabIndex = 4;
            lblLank.Text = "Ange en RSS-länk";
            // 
            // lbxAvsnitt
            // 
            lbxAvsnitt.FormattingEnabled = true;
            lbxAvsnitt.Location = new Point(447, 425);
            lbxAvsnitt.Margin = new Padding(4, 4, 4, 4);
            lbxAvsnitt.Name = "lbxAvsnitt";
            lbxAvsnitt.Size = new Size(350, 388);
            lbxAvsnitt.TabIndex = 5;
            // 
            // lbxInfo
            // 
            lbxInfo.FormattingEnabled = true;
            lbxInfo.Location = new Point(819, 425);
            lbxInfo.Margin = new Padding(4, 4, 4, 4);
            lbxInfo.Name = "lbxInfo";
            lbxInfo.Size = new Size(350, 388);
            lbxInfo.TabIndex = 6;
            // 
            // btnAndra
            // 
            btnAndra.ForeColor = Color.Black;
            btnAndra.Location = new Point(265, 335);
            btnAndra.Margin = new Padding(4, 4, 4, 4);
            btnAndra.Name = "btnAndra";
            btnAndra.Size = new Size(146, 44);
            btnAndra.TabIndex = 7;
            btnAndra.Text = "Ändra";
            btnAndra.UseVisualStyleBackColor = true;
            // 
            // btnTabort
            // 
            btnTabort.Location = new Point(447, 335);
            btnTabort.Margin = new Padding(4, 4, 4, 4);
            btnTabort.Name = "btnTabort";
            btnTabort.Size = new Size(146, 44);
            btnTabort.TabIndex = 8;
            btnTabort.Text = "Ta bort";
            btnTabort.UseVisualStyleBackColor = true;
            // 
            // cbxKategori
            // 
            cbxKategori.FormattingEnabled = true;
            cbxKategori.Location = new Point(237, 274);
            cbxKategori.Margin = new Padding(4, 4, 4, 4);
            cbxKategori.Name = "cbxKategori";
            cbxKategori.Size = new Size(300, 40);
            cbxKategori.TabIndex = 9;
            cbxKategori.Text = "Välj Kategori";
            // 
            // lblKategori
            // 
            lblKategori.AutoSize = true;
            lblKategori.Location = new Point(1149, 78);
            lblKategori.Margin = new Padding(4, 0, 4, 0);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(597, 32);
            lblKategori.TabIndex = 10;
            lblKategori.Text = "Här kan du lägga till/ ändra eller ta bort en ny kategori";
            // 
            // btnAndraKategori
            // 
            btnAndraKategori.Location = new Point(1358, 191);
            btnAndraKategori.Margin = new Padding(4, 4, 4, 4);
            btnAndraKategori.Name = "btnAndraKategori";
            btnAndraKategori.Size = new Size(146, 44);
            btnAndraKategori.TabIndex = 11;
            btnAndraKategori.Text = "Ändra";
            btnAndraKategori.UseVisualStyleBackColor = true;
            btnAndraKategori.Click += btnAndraKategori_Click_1;
            // 
            // btnLaggTillKategori
            // 
            btnLaggTillKategori.Location = new Point(1202, 191);
            btnLaggTillKategori.Margin = new Padding(4, 4, 4, 4);
            btnLaggTillKategori.Name = "btnLaggTillKategori";
            btnLaggTillKategori.Size = new Size(146, 44);
            btnLaggTillKategori.TabIndex = 12;
            btnLaggTillKategori.Text = "Lägg Till";
            btnLaggTillKategori.UseVisualStyleBackColor = true;
            btnLaggTillKategori.Click += btnLaggTillKategori_Click;
            // 
            // btnTaBortKategori
            // 
            btnTaBortKategori.Location = new Point(1521, 191);
            btnTaBortKategori.Margin = new Padding(4, 4, 4, 4);
            btnTaBortKategori.Name = "btnTaBortKategori";
            btnTaBortKategori.Size = new Size(146, 44);
            btnTaBortKategori.TabIndex = 13;
            btnTaBortKategori.Text = "Ta Bort";
            btnTaBortKategori.UseVisualStyleBackColor = true;
            btnTaBortKategori.Click += btnTaBortKategori_Click_1;
            // 
            // lbxKategori
            // 
            lbxKategori.FormattingEnabled = true;
            lbxKategori.Location = new Point(1262, 265);
            lbxKategori.Margin = new Padding(4, 4, 4, 4);
            lbxKategori.Name = "lbxKategori";
            lbxKategori.Size = new Size(350, 548);
            lbxKategori.TabIndex = 14;
            lbxKategori.SelectedIndexChanged += lbxKategori_SelectedIndexChanged_1;
            // 
            // lblTitelPodd
            // 
            lblTitelPodd.AutoSize = true;
            lblTitelPodd.Font = new Font("Segoe UI", 14F);
            lblTitelPodd.Location = new Point(649, 12);
            lblTitelPodd.Name = "lblTitelPodd";
            lblTitelPodd.Size = new Size(299, 51);
            lblTitelPodd.TabIndex = 17;
            lblTitelPodd.Text = "PoddApplikation";
            // 
            // txbNamn
            // 
            txbNamn.Location = new Point(237, 210);
            txbNamn.Margin = new Padding(4, 4, 4, 4);
            txbNamn.Name = "txbNamn";
            txbNamn.Size = new Size(300, 39);
            txbNamn.TabIndex = 18;
            // 
            // lblNamngePodd
            // 
            lblNamngePodd.AutoSize = true;
            lblNamngePodd.Location = new Point(43, 210);
            lblNamngePodd.Margin = new Padding(4, 0, 4, 0);
            lblNamngePodd.Name = "lblNamngePodd";
            lblNamngePodd.Size = new Size(167, 32);
            lblNamngePodd.TabIndex = 19;
            lblNamngePodd.Text = "Namnge Podd";
            // 
            // tbxKategori
            // 
            tbxKategori.Location = new Point(1262, 127);
            tbxKategori.Margin = new Padding(4, 4, 4, 4);
            tbxKategori.Name = "tbxKategori";
            tbxKategori.Size = new Size(350, 39);
            tbxKategori.TabIndex = 20;
            // 
            // lblPoddar
            // 
            lblPoddar.AutoSize = true;
            lblPoddar.Location = new Point(152, 389);
            lblPoddar.Margin = new Padding(4, 0, 4, 0);
            lblPoddar.Name = "lblPoddar";
            lblPoddar.Size = new Size(88, 32);
            lblPoddar.TabIndex = 21;
            lblPoddar.Text = "Poddar";
            // 
            // lblAvsnitt
            // 
            lblAvsnitt.AutoSize = true;
            lblAvsnitt.Location = new Point(559, 383);
            lblAvsnitt.Margin = new Padding(4, 0, 4, 0);
            lblAvsnitt.Name = "lblAvsnitt";
            lblAvsnitt.Size = new Size(87, 32);
            lblAvsnitt.TabIndex = 22;
            lblAvsnitt.Text = "Avsnitt";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(887, 383);
            lblInfo.Margin = new Padding(4, 0, 4, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(139, 32);
            lblInfo.TabIndex = 23;
            lblInfo.Text = "Avsnittsinfo";
            // 
            // btnFiltrera
            // 
            btnFiltrera.Location = new Point(592, 274);
            btnFiltrera.Margin = new Padding(4, 4, 4, 4);
            btnFiltrera.Name = "btnFiltrera";
            btnFiltrera.Size = new Size(146, 44);
            btnFiltrera.TabIndex = 24;
            btnFiltrera.Text = "Filtrera";
            btnFiltrera.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1820, 850);
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
            Controls.Add(lbxInfo);
            Controls.Add(lbxAvsnitt);
            Controls.Add(lblLank);
            Controls.Add(txtbRSS);
            Controls.Add(lbxMinaPoddar);
            Controls.Add(lblTitel);
            Controls.Add(btnSök);
            Margin = new Padding(4, 4, 4, 4);
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
        private ListBox lbxInfo;
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
    }
}
