namespace Proiect1
{
    partial class FormBilet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBilet));
            this.dataGridViewMeci = new System.Windows.Forms.DataGridView();
            this.ClmData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmMeci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmTip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCotaTotala = new System.Windows.Forms.TextBox();
            this.tbMiza = new System.Windows.Forms.TextBox();
            this.tbCastig = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnSalveaza = new Proiect1.Buton();
            this.btnRenunta = new Proiect1.Buton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMeci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMeci
            // 
            this.dataGridViewMeci.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridViewMeci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMeci.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmData,
            this.ClmMeci,
            this.ClmTip,
            this.ClmCota});
            this.dataGridViewMeci.Location = new System.Drawing.Point(14, 78);
            this.dataGridViewMeci.Name = "dataGridViewMeci";
            this.dataGridViewMeci.Size = new System.Drawing.Size(517, 164);
            this.dataGridViewMeci.TabIndex = 0;
            this.dataGridViewMeci.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMeci_CellEndEdit);
            this.dataGridViewMeci.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewMeci_CellValidating);
            // 
            // ClmData
            // 
            this.ClmData.HeaderText = "Data";
            this.ClmData.Name = "ClmData";
            // 
            // ClmMeci
            // 
            this.ClmMeci.HeaderText = "Meci";
            this.ClmMeci.Name = "ClmMeci";
            // 
            // ClmTip
            // 
            this.ClmTip.HeaderText = "Pronostic";
            this.ClmTip.Name = "ClmTip";
            // 
            // ClmCota
            // 
            this.ClmCota.HeaderText = "Cota";
            this.ClmCota.Name = "ClmCota";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cota totala";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Miza";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valoare castig";
            // 
            // tbCotaTotala
            // 
            this.tbCotaTotala.Location = new System.Drawing.Point(121, 291);
            this.tbCotaTotala.Name = "tbCotaTotala";
            this.tbCotaTotala.ReadOnly = true;
            this.tbCotaTotala.Size = new System.Drawing.Size(116, 22);
            this.tbCotaTotala.TabIndex = 5;
            this.tbCotaTotala.Click += new System.EventHandler(this.tbCotaTotala_Click);
            // 
            // tbMiza
            // 
            this.tbMiza.Location = new System.Drawing.Point(121, 337);
            this.tbMiza.Name = "tbMiza";
            this.tbMiza.Size = new System.Drawing.Size(116, 22);
            this.tbMiza.TabIndex = 6;
            this.tbMiza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMiza_KeyPress);
            // 
            // tbCastig
            // 
            this.tbCastig.Location = new System.Drawing.Point(121, 383);
            this.tbCastig.Name = "tbCastig";
            this.tbCastig.ReadOnly = true;
            this.tbCastig.Size = new System.Drawing.Size(116, 22);
            this.tbCastig.TabIndex = 7;
            this.tbCastig.Click += new System.EventHandler(this.tbCastig_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(551, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Descarca bilet";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(444, 438);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(87, 25);
            this.btnSalveaza.TabIndex = 12;
            this.btnSalveaza.Text = "Salveaza";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click_1);
            // 
            // btnRenunta
            // 
            this.btnRenunta.Location = new System.Drawing.Point(309, 438);
            this.btnRenunta.Name = "btnRenunta";
            this.btnRenunta.Size = new System.Drawing.Size(87, 25);
            this.btnRenunta.TabIndex = 11;
            this.btnRenunta.Text = "Renunta";
            this.btnRenunta.UseVisualStyleBackColor = true;
            this.btnRenunta.Click += new System.EventHandler(this.btnRenunta_Click_1);
            // 
            // FormBilet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(551, 485);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.btnRenunta);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tbCastig);
            this.Controls.Add(this.tbMiza);
            this.Controls.Add(this.tbCotaTotala);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewMeci);
            this.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBilet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBilet";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMeci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMeci;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCotaTotala;
        private System.Windows.Forms.TextBox tbMiza;
        private System.Windows.Forms.TextBox tbCastig;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmMeci;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCota;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Buton btnSalveaza;
        private Buton btnRenunta;
    }
}