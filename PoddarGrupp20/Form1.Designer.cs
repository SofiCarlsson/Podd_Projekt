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
            btnSök.Location = new Point(29, 262);
            btnSök.Name = "btnSök";
            btnSök.Size = new Size(147, 34);
            btnSök.TabIndex = 0;
            btnSök.Text = "Prenumerera";
            btnSök.UseVisualStyleBackColor = true;
            // 
            // lblTitel
            // 
            lblTitel.AutoSize = true;
            lblTitel.Location = new Point(542, 9);
            lblTitel.Name = "lblTitel";
            lblTitel.Size = new Size(0, 25);
            lblTitel.TabIndex = 1;
            // 
            // lbxMinaPoddar
            // 
            lbxMinaPoddar.FormattingEnabled = true;
            lbxMinaPoddar.ItemHeight = 25;
            lbxMinaPoddar.Location = new Point(46, 332);
            lbxMinaPoddar.Name = "lbxMinaPoddar";
            lbxMinaPoddar.Size = new Size(270, 304);
            lbxMinaPoddar.TabIndex = 2;
            // 
            // txtbRSS
            // 
            txtbRSS.Location = new Point(182, 99);
            txtbRSS.Name = "txtbRSS";
            txtbRSS.Size = new Size(232, 31);
            txtbRSS.TabIndex = 3;
            // 
            // lblLank
            // 
            lblLank.AutoSize = true;
            lblLank.Location = new Point(23, 105);
            lblLank.Name = "lblLank";
            lblLank.Size = new Size(153, 25);
            lblLank.TabIndex = 4;
            lblLank.Text = "Ange en RSS-länk";
            // 
            // lbxAvsnitt
            // 
            lbxAvsnitt.FormattingEnabled = true;
            lbxAvsnitt.ItemHeight = 25;
            lbxAvsnitt.Location = new Point(344, 332);
            lbxAvsnitt.Name = "lbxAvsnitt";
            lbxAvsnitt.Size = new Size(270, 304);
            lbxAvsnitt.TabIndex = 5;
            // 
            // lbxInfo
            // 
            lbxInfo.FormattingEnabled = true;
            lbxInfo.ItemHeight = 25;
            lbxInfo.Location = new Point(630, 332);
            lbxInfo.Name = "lbxInfo";
            lbxInfo.Size = new Size(270, 304);
            lbxInfo.TabIndex = 6;
            // 
            // btnAndra
            // 
            btnAndra.ForeColor = Color.Black;
            btnAndra.Location = new Point(204, 262);
            btnAndra.Name = "btnAndra";
            btnAndra.Size = new Size(112, 34);
            btnAndra.TabIndex = 7;
            btnAndra.Text = "Ändra";
            btnAndra.UseVisualStyleBackColor = true;
            // 
            // btnTabort
            // 
            btnTabort.Location = new Point(344, 262);
            btnTabort.Name = "btnTabort";
            btnTabort.Size = new Size(112, 34);
            btnTabort.TabIndex = 8;
            btnTabort.Text = "Ta bort";
            btnTabort.UseVisualStyleBackColor = true;
            // 
            // cbxKategori
            // 
            cbxKategori.FormattingEnabled = true;
            cbxKategori.Location = new Point(182, 214);
            cbxKategori.Name = "cbxKategori";
            cbxKategori.Size = new Size(232, 33);
            cbxKategori.TabIndex = 9;
            cbxKategori.Text = "Välj Kategori";
            // 
            // lblKategori
            // 
            lblKategori.AutoSize = true;
            lblKategori.Location = new Point(884, 61);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(442, 25);
            lblKategori.TabIndex = 10;
            lblKategori.Text = "Här kan du lägga till/ ändra eller ta bort en ny kategori";
            // 
            // btnAndraKategori
            // 
            btnAndraKategori.Location = new Point(1045, 149);
            btnAndraKategori.Name = "btnAndraKategori";
            btnAndraKategori.Size = new Size(112, 34);
            btnAndraKategori.TabIndex = 11;
            btnAndraKategori.Text = "Ändra";
            btnAndraKategori.UseVisualStyleBackColor = true;
            // 
            // btnLaggTillKategori
            // 
            btnLaggTillKategori.Location = new Point(925, 149);
            btnLaggTillKategori.Name = "btnLaggTillKategori";
            btnLaggTillKategori.Size = new Size(112, 34);
            btnLaggTillKategori.TabIndex = 12;
            btnLaggTillKategori.Text = "Lägg Till";
            btnLaggTillKategori.UseVisualStyleBackColor = true;
            // 
            // btnTaBortKategori
            // 
            btnTaBortKategori.Location = new Point(1170, 149);
            btnTaBortKategori.Name = "btnTaBortKategori";
            btnTaBortKategori.Size = new Size(112, 34);
            btnTaBortKategori.TabIndex = 13;
            btnTaBortKategori.Text = "Ta Bort";
            btnTaBortKategori.UseVisualStyleBackColor = true;
            // 
            // lbxKategori
            // 
            lbxKategori.FormattingEnabled = true;
            lbxKategori.ItemHeight = 25;
            lbxKategori.Location = new Point(971, 207);
            lbxKategori.Name = "lbxKategori";
            lbxKategori.Size = new Size(270, 429);
            lbxKategori.TabIndex = 14;
            // 
            // lblTitelPodd
            // 
            lblTitelPodd.AutoSize = true;
            lblTitelPodd.Font = new Font("Segoe UI", 14F);
            lblTitelPodd.Location = new Point(499, 9);
            lblTitelPodd.Margin = new Padding(2, 0, 2, 0);
            lblTitelPodd.Name = "lblTitelPodd";
            lblTitelPodd.Size = new Size(220, 38);
            lblTitelPodd.TabIndex = 17;
            lblTitelPodd.Text = "PoddApplikation";
            // 
            // txbNamn
            // 
            txbNamn.Location = new Point(182, 164);
            txbNamn.Name = "txbNamn";
            txbNamn.Size = new Size(232, 31);
            txbNamn.TabIndex = 18;
            // 
            // lblNamngePodd
            // 
            lblNamngePodd.AutoSize = true;
            lblNamngePodd.Location = new Point(33, 164);
            lblNamngePodd.Name = "lblNamngePodd";
            lblNamngePodd.Size = new Size(127, 25);
            lblNamngePodd.TabIndex = 19;
            lblNamngePodd.Text = "Namnge Podd";
            // 
            // tbxKategori
            // 
            tbxKategori.Location = new Point(971, 99);
            tbxKategori.Name = "tbxKategori";
            tbxKategori.Size = new Size(270, 31);
            tbxKategori.TabIndex = 20;
            // 
            // lblPoddar
            // 
            lblPoddar.AutoSize = true;
            lblPoddar.Location = new Point(117, 304);
            lblPoddar.Name = "lblPoddar";
            lblPoddar.Size = new Size(69, 25);
            lblPoddar.TabIndex = 21;
            lblPoddar.Text = "Poddar";
            // 
            // lblAvsnitt
            // 
            lblAvsnitt.AutoSize = true;
            lblAvsnitt.Location = new Point(430, 299);
            lblAvsnitt.Name = "lblAvsnitt";
            lblAvsnitt.Size = new Size(67, 25);
            lblAvsnitt.TabIndex = 22;
            lblAvsnitt.Text = "Avsnitt";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(682, 299);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(106, 25);
            lblInfo.TabIndex = 23;
            lblInfo.Text = "Avsnittsinfo";
            // 
            // btnFiltrera
            // 
            btnFiltrera.Location = new Point(455, 214);
            btnFiltrera.Name = "btnFiltrera";
            btnFiltrera.Size = new Size(112, 34);
            btnFiltrera.TabIndex = 24;
            btnFiltrera.Text = "Filtrera";
            btnFiltrera.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 664);
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
