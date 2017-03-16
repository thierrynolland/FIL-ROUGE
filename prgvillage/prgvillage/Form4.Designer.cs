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
            this.button1 = new System.Windows.Forms.Button();
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
            this.button21 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.label53 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.comboBox21 = new System.Windows.Forms.ComboBox();
            this.comboBox22 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.villagegreenDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView2.Location = new System.Drawing.Point(7, 205);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1027, 209);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 55;
            this.button1.Text = "<-- retour";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 433);
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
            this.dataGridView1.Location = new System.Drawing.Point(7, 456);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1008, 274);
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
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Orange;
            this.button21.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button21.FlatAppearance.BorderSize = 2;
            this.button21.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.Location = new System.Drawing.Point(610, 154);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(163, 45);
            this.button21.TabIndex = 158;
            this.button21.Text = "SUPPRIMER";
            this.button21.UseVisualStyleBackColor = false;
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.Orange;
            this.button24.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button24.FlatAppearance.BorderSize = 2;
            this.button24.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button24.Location = new System.Drawing.Point(610, 79);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(163, 45);
            this.button24.TabIndex = 157;
            this.button24.Text = "MODIFIER";
            this.button24.UseVisualStyleBackColor = false;
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.Orange;
            this.button25.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button25.FlatAppearance.BorderSize = 2;
            this.button25.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button25.Location = new System.Drawing.Point(610, 11);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(163, 45);
            this.button25.TabIndex = 156;
            this.button25.Text = "AJOUTER";
            this.button25.UseVisualStyleBackColor = false;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Sitka Banner", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(31, 170);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(76, 28);
            this.label53.TabIndex = 179;
            this.label53.Text = "Quantité";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(162, 171);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(106, 20);
            this.textBox11.TabIndex = 178;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Sitka Banner", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(28, 36);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(107, 28);
            this.label50.TabIndex = 177;
            this.label50.Text = "Code produit";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Sitka Banner", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(28, 116);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(117, 28);
            this.label51.TabIndex = 176;
            this.label51.Text = "Sous Rubrique";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Sitka Banner", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(28, 73);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(79, 28);
            this.label52.TabIndex = 175;
            this.label52.Text = "Rubrique";
            // 
            // comboBox21
            // 
            this.comboBox21.FormattingEnabled = true;
            this.comboBox21.Location = new System.Drawing.Point(162, 116);
            this.comboBox21.Name = "comboBox21";
            this.comboBox21.Size = new System.Drawing.Size(278, 21);
            this.comboBox21.TabIndex = 174;
            // 
            // comboBox22
            // 
            this.comboBox22.FormattingEnabled = true;
            this.comboBox22.Location = new System.Drawing.Point(162, 72);
            this.comboBox22.Name = "comboBox22";
            this.comboBox22.Size = new System.Drawing.Size(278, 21);
            this.comboBox22.TabIndex = 173;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(162, 36);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(105, 20);
            this.textBox4.TabIndex = 172;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(725, 421);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 32);
            this.button2.TabIndex = 180;
            this.button2.Text = " Annuler";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(890, 421);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 32);
            this.button3.TabIndex = 181;
            this.button3.Text = " Valider";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 780);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.comboBox21);
            this.Controls.Add(this.comboBox22);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.villagegreenDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.ComboBox comboBox21;
        private System.Windows.Forms.ComboBox comboBox22;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}