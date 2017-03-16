using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MesClasses;
using System.Text.RegularExpressions;

namespace prgvillage
{
    public partial class Form2 : Form
    {
        int choixFour = 1;
        bool validiteF;
        bool valNomF,valAdresseF,valVilleF,valCPF;
        int numerof=-1;
        Fournisseur FournisseurChoisi;

        public Form2()
        {
            InitializeComponent();
        }


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

            InitialiserListesFour();
             validiteF=false;
             valNomF = true;
             valAdresseF = true;
             valVilleF = true;
             valCPF=true;

        }
        public void InitialiserListesFour()
        {
             // on remplit la liste des noms fournisseurs
            comboBoxFourNom.ValueMember = "Id";
            comboBoxFourNom.DisplayMember = "IDetNom";
            FournisseurDAO ListeDesFournisseursNom;
            ListeDesFournisseursNom = new FournisseurDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxFourNom.DataSource = ListeDesFournisseursNom.List();

            //et on met le focus sur le code fournisseur sur aucun choix
            comboBoxFourNom.Focus();
            comboBoxFourNom.SelectedIndex = -1;
            //griser le bouton modifier
            buttonFourModifier.Enabled = false;
            buttonFourModifier.BackColor = Color.Peru;
            //cacher la partie de droite
            groupBoxFour.Visible = false;
        }

   

        private void comboBoxFourNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonFourModifier.Enabled = true;
            buttonFourModifier.BackColor = Color.Orange;
          
            if (comboBoxFourNom.SelectedIndex!=-1)
            {
            numerof = Convert.ToInt32(comboBoxFourNom.SelectedValue.ToString());
                Console.WriteLine("numero ID : " +numerof);    
            }

                     
        }

        private void buttonFourAnnuler_Click(object sender, EventArgs e)
        {
            MontrerBoutons();
            buttonFourModifier.Enabled = false;
            buttonFourModifier.BackColor = Color.Peru;
            groupBoxFour.Visible = false;
        }
        public bool verifValiditeF()
        {
            bool valideF = false;

            if ((valNomF&&valAdresseF&&valVilleF&&valCPF)&&(textBoxFourNom.Text !=""))
            {
                valideF = true;
            }
            else
            {
                MessageBox.Show("Erreur de saisie, modifiez la saisie", "ERREUR");
            }
            return valideF;
        }
        public void CacherCoteDroit()
        {
            groupBoxFour.Visible = false;
        }
        public void CacherBoutons()
        {
            buttonFourAJouter.Visible = false;
            buttonFourModifier.Visible = false;
            comboBoxFourNom.Enabled = false;
        }

        public void MontrerBoutons()
        {
         buttonFourAJouter.Visible = true;
         buttonFourModifier.Visible = true;
         buttonFourModifier.Enabled = false;
         buttonFourModifier.BackColor = Color.Peru;
         comboBoxFourNom.Enabled = true;
        }

       
                            
        private void buttonFourValider_Click(object sender, EventArgs e)
        {
           
            validiteF = verifValiditeF();
            switch (choixFour)
            {
                case 1:
                    //Choix : Ajouter Fournisseur
                    if (validiteF)
                    {
                        Fournisseur NouveauF = new Fournisseur();
                        NouveauF.Nom = textBoxFourNom.Text;
                        NouveauF.Adresse = textBoxFourAdresse.Text;
                        NouveauF.CP = textBoxFourCP.Text;
                        NouveauF.Ville = textBoxFourVille.Text;
                        FournisseurDAO InsertionFour;
                        InsertionFour = new FournisseurDAO("server=.;database=villagegreen;Integrated Security = True");
                        try
                        {
                            InsertionFour.Insert(NouveauF);
                            MessageBox.Show("INSERTION REUSSIE", "MESSAGE IMPORTANT");

                            CacherCoteDroit();
                            MontrerBoutons();
                            InitialiserListesFour();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("PROBLEME INSERTION NON REUSSIE ", "MESSAGE IMPORTANT");
                        }
                    }
                    
                    break;
                case 2:
                    //Choix : Modifier Fournisseur
                    Console.WriteLine("validiteF {0} NOM {1} ADRESSE {2} CP {3} VILLE {4}",validiteF,valNomF,valAdresseF,valCPF,valVilleF);
                    if (validiteF)
                    {
                        Fournisseur NouveauMod = new Fournisseur();
                        NouveauMod.Id = numerof;
                        NouveauMod.Nom = textBoxFourNom.Text;
                        NouveauMod.Adresse = textBoxFourAdresse.Text;
                        NouveauMod.CP = textBoxFourCP.Text;
                        NouveauMod.Ville = textBoxFourVille.Text;
                        Console.WriteLine("données fournisseur" + NouveauMod.Id+NouveauMod.Nom+NouveauMod.Adresse+ NouveauMod.CP+ NouveauMod.Ville);
                        FournisseurDAO ModifFour;
                        ModifFour = new FournisseurDAO("server=.;database=villagegreen;Integrated Security = True");
                        try
                        {
                            ModifFour.Update(NouveauMod);
                            MessageBox.Show("MODIFICATION REUSSIE", "MESSAGE IMPORTANT");

                            CacherCoteDroit();
                            MontrerBoutons();
                            InitialiserListesFour();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("PROBLEME MODIFICATION NON REUSSIE ", "MESSAGE IMPORTANT");
                        }
                    }
                                        
                    break;
            }
            
        }
        public void AfficherFournisseur()
        {
            Fournisseur FournisseurAAfficher = new Fournisseur();
            FournisseurAAfficher = Trouver(numerof);
            FournisseurChoisi = FournisseurAAfficher;
            textBoxFourNom.Text = FournisseurAAfficher.Nom;
            textBoxFourAdresse.Text = FournisseurAAfficher.Adresse;
            textBoxFourCP.Text = FournisseurAAfficher.CP;
            textBoxFourVille.Text = FournisseurAAfficher.Ville;
        }

        public Fournisseur Trouver(int paramNum)
        {
            FournisseurDAO Trouve;
            Trouve = new FournisseurDAO("server=.;database=villagegreen;Integrated Security = True");
            Fournisseur FournisseurTrouve;
            FournisseurTrouve = Trouve.Find(paramNum);
            //int numfourisseur = FournisseurTrouve.Id;
            //string nomfournisseur = FournisseurTrouve.Nom;
            //string ville = FournisseurTrouve.Ville;
            //string cp = FournisseurTrouve.CP;
            //string adresse = FournisseurTrouve.Adresse;
            return FournisseurTrouve;
        }

        

        private void textBoxFourVille_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBoxFourVille.Text, @"[A-Z]+([a-z A-Z'îêâôûœïëüäö]{1,99})?$") == false) || (textBoxFourVille.Text == ""))
            {
                textBoxFourVille.BackColor = Color.Red;
                valVilleF = false;
            }
            else
            {
                textBoxFourVille.BackColor = Color.White;
                valVilleF = true;
            }
        }

        private void textBoxFourAdresse_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBoxFourAdresse.Text, @"[a-z A-Z0-9'îêâôûœïëüäö]{1,99}$") == false) || (textBoxFourAdresse.Text == ""))
            {
                textBoxFourAdresse.BackColor = Color.Red;
                valAdresseF = false;
            }
            else
            {
                textBoxFourAdresse.BackColor = Color.White;
                valAdresseF = true;
            }
        }

        private void textBoxFourCP_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBoxFourCP.Text, @"[0-9A-Z]{5}$") == false) || (textBoxFourCP.Text == ""))
            {
                textBoxFourCP.BackColor = Color.Red;
                valCPF = false;
            }
            else
            {
                textBoxFourCP.BackColor = Color.White;
                valCPF = true;
            }
        }

        private void buttonFourAJouter_Click(object sender, EventArgs e)
        {
            groupBoxFour.Visible = true;
            choixFour = 1;
            CacherBoutons();
            effacerChampsF();
            textBoxFourNom.BackColor = Color.White;
            textBoxFourAdresse.BackColor = Color.White;
            textBoxFourCP.BackColor = Color.White;
            textBoxFourVille.BackColor = Color.White;
            validiteF = false;
            valNomF = true;
            valAdresseF = true;
            valVilleF = true;
            valCPF = true;
        }

        private void tabControl7_Selected(object sender, TabControlEventArgs e)
        {
            //Au chargement on affiche le total des CA Fournisseur.
            FournisseurDAO trouveCATotaFour;
            trouveCATotaFour = new FournisseurDAO("server =.; database = villagegreen; Integrated Security = True");
            textBoxTotalFourCA.Text = Convert.ToString(trouveCATotaFour.TrouverCATotalFournisseur());

            //puis on remplit la liste des fournisseur dans la ComboBox.
            comboBoxFourCA.ValueMember = "Id";
            comboBoxFourCA.DisplayMember = "IDetNom";
            FournisseurDAO ListeDesFournisseursNom;
            ListeDesFournisseursNom = new FournisseurDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxFourCA.DataSource = ListeDesFournisseursNom.List();
            comboBoxFourCA.Focus();

           

            //puis dans la DatagridView

            
            CAFournisseurDAO ListeDesCAFournisseurs2;
            ListeDesCAFournisseurs2 = new CAFournisseurDAO("server =.; database = villagegreen; Integrated Security = True");
            dataGridViewCAFour.DataSource = ListeDesCAFournisseurs2.ListCAFour();
            dataGridViewCAFour.Columns[0].HeaderText = "ID Fournisseur";
            dataGridViewCAFour.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //comboBoxFourCA.Focus();






        }

        private void comboBoxFourCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            FournisseurDAO trouveCAFour;
            trouveCAFour = new FournisseurDAO("server =.; database = villagegreen; Integrated Security = True");
            textBoxFourCA.Text = Convert.ToString(trouveCAFour.TrouverCAFournisseur(Convert.ToInt32(comboBoxFourCA.SelectedValue)));

        }

        public void effacerChampsF()
        {
            textBoxFourNom.Text = "";
            textBoxFourAdresse.Text = "";
            textBoxFourCP.Text = "";
            textBoxFourVille.Text = "";

        }

        private void buttonFourModifier_Click(object sender, EventArgs e)
        {
            groupBoxFour.Visible = true;
            choixFour = 2;
            CacherBoutons();
            Console.WriteLine("numero ID avant : " + numerof);
            AfficherFournisseur();
            Console.WriteLine("numero ID apres: " + numerof);
            validiteF = false;
            valNomF = true;
            valAdresseF = true;
            valVilleF = true;
            valCPF = true;
        }

        private void textBoxFourNom_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBoxFourNom.Text, @"[A-Z]+([a-z A-Z'îêâôûœïëüäö]{1,49})?$") == false) || (textBoxFourNom.Text == ""))
            {
                textBoxFourNom.BackColor = Color.Red;
                valNomF = false;
            }
            else
            {
                textBoxFourNom.BackColor = Color.White;
                valNomF = true;
            }
        }
    }
}
