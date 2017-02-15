namespace prgvillage
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.villagegreenDataSet2 = new prgvillage.villagegreenDataSet2();
            this.produitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produitTableAdapter = new prgvillage.villagegreenDataSet2TableAdapters.produitTableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.produitidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produitnomcourtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produitnomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produitphotoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produitprixachatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produitetatDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.produitprixhtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produitvaliditeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ssrubriqueidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fournisseuridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tvaidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.villagegreenDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(828, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 40);
            this.button2.TabIndex = 42;
            this.button2.Text = "AJOUTER PRODUIT";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(138, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(105, 20);
            this.textBox2.TabIndex = 44;
            // 
            // villagegreenDataSet2
            // 
            this.villagegreenDataSet2.DataSetName = "villagegreenDataSet2";
            this.villagegreenDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // produitBindingSource
            // 
            this.produitBindingSource.DataMember = "produit";
            this.produitBindingSource.DataSource = this.villagegreenDataSet2;
            // 
            // produitTableAdapter
            // 
            this.produitTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dataGridView2.DataSource = this.produitBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(2, 198);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1027, 284);
            this.dataGridView2.TabIndex = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "produit_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "produit_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "produit_nomcourt";
            this.dataGridViewTextBoxColumn2.HeaderText = "produit_nomcourt";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "produit_nom";
            this.dataGridViewTextBoxColumn3.HeaderText = "produit_nom";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "produit_photo";
            this.dataGridViewTextBoxColumn4.HeaderText = "produit_photo";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "produit_prixachat";
            this.dataGridViewTextBoxColumn5.HeaderText = "produit_prixachat";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "produit_etat";
            this.dataGridViewCheckBoxColumn1.HeaderText = "produit_etat";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "produit_prixht";
            this.dataGridViewTextBoxColumn6.HeaderText = "produit_prixht";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "produit_validite";
            this.dataGridViewCheckBoxColumn2.HeaderText = "produit_validite";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ss_rubrique_id";
            this.dataGridViewTextBoxColumn7.HeaderText = "ss_rubrique_id";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "fournisseur_id";
            this.dataGridViewTextBoxColumn8.HeaderText = "fournisseur_id";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "tva_id";
            this.dataGridViewTextBoxColumn9.HeaderText = "tva_id";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 54;
            this.label2.Text = "Sous Rubrique";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Rubrique";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(138, 150);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(278, 21);
            this.comboBox2.TabIndex = 52;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(138, 106);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(278, 21);
            this.comboBox1.TabIndex = 51;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 55;
            this.button1.Text = "<-- retour";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(644, 141);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(106, 20);
            this.textBox3.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(560, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 57;
            this.label3.Text = "Quantité";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 61;
            this.label5.Text = "Code produit";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(259, 70);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 20);
            this.button4.TabIndex = 62;
            this.button4.Text = "ok";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 505);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 20);
            this.label4.TabIndex = 63;
            this.label4.Text = "Produits dans la commande";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.produitidDataGridViewTextBoxColumn,
            this.produitnomcourtDataGridViewTextBoxColumn,
            this.produitnomDataGridViewTextBoxColumn,
            this.produitphotoDataGridViewTextBoxColumn,
            this.produitprixachatDataGridViewTextBoxColumn,
            this.produitetatDataGridViewCheckBoxColumn,
            this.produitprixhtDataGridViewTextBoxColumn,
            this.produitvaliditeDataGridViewCheckBoxColumn,
            this.ssrubriqueidDataGridViewTextBoxColumn,
            this.fournisseuridDataGridViewTextBoxColumn,
            this.tvaidDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.produitBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(7, 537);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1008, 193);
            this.dataGridView1.TabIndex = 64;
            // 
            // produitidDataGridViewTextBoxColumn
            // 
            this.produitidDataGridViewTextBoxColumn.DataPropertyName = "produit_id";
            this.produitidDataGridViewTextBoxColumn.HeaderText = "produit_id";
            this.produitidDataGridViewTextBoxColumn.Name = "produitidDataGridViewTextBoxColumn";
            // 
            // produitnomcourtDataGridViewTextBoxColumn
            // 
            this.produitnomcourtDataGridViewTextBoxColumn.DataPropertyName = "produit_nomcourt";
            this.produitnomcourtDataGridViewTextBoxColumn.HeaderText = "produit_nomcourt";
            this.produitnomcourtDataGridViewTextBoxColumn.Name = "produitnomcourtDataGridViewTextBoxColumn";
            // 
            // produitnomDataGridViewTextBoxColumn
            // 
            this.produitnomDataGridViewTextBoxColumn.DataPropertyName = "produit_nom";
            this.produitnomDataGridViewTextBoxColumn.HeaderText = "produit_nom";
            this.produitnomDataGridViewTextBoxColumn.Name = "produitnomDataGridViewTextBoxColumn";
            // 
            // produitphotoDataGridViewTextBoxColumn
            // 
            this.produitphotoDataGridViewTextBoxColumn.DataPropertyName = "produit_photo";
            this.produitphotoDataGridViewTextBoxColumn.HeaderText = "produit_photo";
            this.produitphotoDataGridViewTextBoxColumn.Name = "produitphotoDataGridViewTextBoxColumn";
            // 
            // produitprixachatDataGridViewTextBoxColumn
            // 
            this.produitprixachatDataGridViewTextBoxColumn.DataPropertyName = "produit_prixachat";
            this.produitprixachatDataGridViewTextBoxColumn.HeaderText = "produit_prixachat";
            this.produitprixachatDataGridViewTextBoxColumn.Name = "produitprixachatDataGridViewTextBoxColumn";
            // 
            // produitetatDataGridViewCheckBoxColumn
            // 
            this.produitetatDataGridViewCheckBoxColumn.DataPropertyName = "produit_etat";
            this.produitetatDataGridViewCheckBoxColumn.HeaderText = "produit_etat";
            this.produitetatDataGridViewCheckBoxColumn.Name = "produitetatDataGridViewCheckBoxColumn";
            // 
            // produitprixhtDataGridViewTextBoxColumn
            // 
            this.produitprixhtDataGridViewTextBoxColumn.DataPropertyName = "produit_prixht";
            this.produitprixhtDataGridViewTextBoxColumn.HeaderText = "produit_prixht";
            this.produitprixhtDataGridViewTextBoxColumn.Name = "produitprixhtDataGridViewTextBoxColumn";
            // 
            // produitvaliditeDataGridViewCheckBoxColumn
            // 
            this.produitvaliditeDataGridViewCheckBoxColumn.DataPropertyName = "produit_validite";
            this.produitvaliditeDataGridViewCheckBoxColumn.HeaderText = "produit_validite";
            this.produitvaliditeDataGridViewCheckBoxColumn.Name = "produitvaliditeDataGridViewCheckBoxColumn";
            // 
            // ssrubriqueidDataGridViewTextBoxColumn
            // 
            this.ssrubriqueidDataGridViewTextBoxColumn.DataPropertyName = "ss_rubrique_id";
            this.ssrubriqueidDataGridViewTextBoxColumn.HeaderText = "ss_rubrique_id";
            this.ssrubriqueidDataGridViewTextBoxColumn.Name = "ssrubriqueidDataGridViewTextBoxColumn";
            // 
            // fournisseuridDataGridViewTextBoxColumn
            // 
            this.fournisseuridDataGridViewTextBoxColumn.DataPropertyName = "fournisseur_id";
            this.fournisseuridDataGridViewTextBoxColumn.HeaderText = "fournisseur_id";
            this.fournisseuridDataGridViewTextBoxColumn.Name = "fournisseuridDataGridViewTextBoxColumn";
            // 
            // tvaidDataGridViewTextBoxColumn
            // 
            this.tvaidDataGridViewTextBoxColumn.DataPropertyName = "tva_id";
            this.tvaidDataGridViewTextBoxColumn.HeaderText = "tva_id";
            this.tvaidDataGridViewTextBoxColumn.Name = "tvaidDataGridViewTextBoxColumn";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(815, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(223, 79);
            this.pictureBox2.TabIndex = 65;
            this.pictureBox2.TabStop = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 780);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.villagegreenDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private villagegreenDataSet2 villagegreenDataSet2;
        private System.Windows.Forms.BindingSource produitBindingSource;
        private villagegreenDataSet2TableAdapters.produitTableAdapter produitTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn produitidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn produitnomcourtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn produitnomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn produitphotoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn produitprixachatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn produitetatDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn produitprixhtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn produitvaliditeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ssrubriqueidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fournisseuridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tvaidDataGridViewTextBoxColumn;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}