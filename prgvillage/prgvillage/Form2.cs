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
      
        string dossier2 = Application.StartupPath+ @"\images\instrumentsdemusique\";
        int choixFour = 1, choixRubrique = 1, choixSSRubrique = 1;
        bool validiteF, valNomF, valAdresseF, valVilleF, valCPF;
        bool valRubriqueNom, valSSRubriqueNom;
        int numerof = -1;
        bool validiteP, valNomCourtP, valNomLongP, validrubP, validssrubP, validtvaP, validfourP, valEtatP, valvalidP;
        bool valprixP,valminiP, valmaxiP;
        int choixprod = 1;
        Fournisseur FournisseurChoisi;
        GroupBox GB1 = new GroupBox();
        Panel P1 = new Panel();
        int TR1;

        public Form2()
        {
            InitializeComponent();
        }


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage5)  //la tabpage 5 est la page fournisseur
            {
                groupBoxFour.Width = 0; //modif
                groupBoxFour.Visible = false; //modif
                panelProduit2.Width = 0;
                panelProduit2.Visible = false;
                InitialiserListesFour();
                validiteF = false;
                valNomF = true;
                valAdresseF = true;
                valVilleF = true;
                valCPF = true;
            }
            if (tabControl1.SelectedTab == tabPage4)
            {
                buttonModifier.Enabled = false;
                textBoxProduitPrixMax.Text = Convert.ToString(0);
                textBoxProduitPrixMini.Text = Convert.ToString(0);
                panelProduit2.Width = 0;
                panelProduit2.Visible = false;
                //remplir les combo
                // le combo des idproduit
                comboBoxProduitID.ValueMember = "Id";
                comboBoxProduitID.DisplayMember = "Id";
                ProduitDAO ListeDesProduits;
                ListeDesProduits = new ProduitDAO("server =.; database = villagegreen; Integrated Security = True");
                comboBoxProduitID.DataSource = ListeDesProduits.List();

                //le combo des rubriques
                comboBoxProduitRub.ValueMember = "Id";
                comboBoxProduitRub.DisplayMember = "Nom";
                RubriqueDAO ListeDesRubriques;
                ListeDesRubriques = new RubriqueDAO("server =.; database = villagegreen; Integrated Security = True");
                comboBoxProduitRub.DataSource = ListeDesRubriques.List();
                comboBoxProduitRub.SelectedIndex = 0;
                // le combo des sous rubriques
                //on remplit la liste des sous rubriques
                initSSRubProduit();

            }
        }
        public void initSSRubProduit()
        {
            comboBoxProduitSSRub.ValueMember = "Id";
            comboBoxProduitSSRub.DisplayMember = "Nom";
            SousRubriqueDAO ListeDesSousRubriques;
            ListeDesSousRubriques = new SousRubriqueDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxProduitSSRub.DataSource = ListeDesSousRubriques.ListSSparRub(Convert.ToInt32(comboBoxProduitRub.SelectedValue));

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
            //groupBoxFour.Visible = false;
        }



        private void comboBoxFourNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonFourModifier.Enabled = true;
            buttonFourModifier.BackColor = Color.Orange;

            if (comboBoxFourNom.SelectedIndex != -1)
            {
                numerof = Convert.ToInt32(comboBoxFourNom.SelectedValue.ToString());
                Console.WriteLine("numero ID : " + numerof);
            }


        }

        private void buttonFourAnnuler_Click(object sender, EventArgs e)
        {

            AnimationFermerGpBox(groupBoxFour);
            MontrerBoutons();
            buttonFourModifier.Enabled = false;
            buttonFourModifier.BackColor = Color.Peru;

        }
        public bool verifValiditeF()
        {
            bool valideF = false;

            if ((valNomF && valAdresseF && valVilleF && valCPF) && (textBoxFourNom.Text != ""))
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

            AnimationFermerGpBox(groupBoxFour);
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
                    Console.WriteLine("validiteF {0} NOM {1} ADRESSE {2} CP {3} VILLE {4}", validiteF, valNomF, valAdresseF, valCPF, valVilleF);
                    if (validiteF)
                    {
                        Fournisseur NouveauMod = new Fournisseur();
                        NouveauMod.Id = numerof;
                        NouveauMod.Nom = textBoxFourNom.Text;
                        NouveauMod.Adresse = textBoxFourAdresse.Text;
                        NouveauMod.CP = textBoxFourCP.Text;
                        NouveauMod.Ville = textBoxFourVille.Text;
                        Console.WriteLine("données fournisseur" + NouveauMod.Id + NouveauMod.Nom + NouveauMod.Adresse + NouveauMod.CP + NouveauMod.Ville);
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
            return FournisseurTrouve;
        }



        private void textBoxFourVille_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBoxFourVille.Text, @"[A-Z]+([a-z A-Z'éèîêâôûœïëüäö]{1,99})?$") == false) || (textBoxFourVille.Text == ""))
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
            if ((Regex.IsMatch(textBoxFourAdresse.Text, @"[a-z A-Z0-9'éèîêâôûœïëüäö]{1,99}$") == false) || (textBoxFourAdresse.Text == ""))
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
            AnimationOuvrirGpBox(groupBoxFour, 500);
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

        private void tabControl5_Selected(object sender, TabControlEventArgs e)
        {

            //ONGLET PRINCIPAL PRODUIT

            if (tabControl5.SelectedTab == tabPage14)//sous Onglet Produit CRUD
            {
                //textBoxProduitPrixMax.Text = Convert.ToString(0);
                //textBoxProduitPrixMini.Text = Convert.ToString(0);
                // groupBoxProduit.Width = 0;
            }

            if (tabControl5.SelectedTab == tabPage1)//sous Onglet Rubrique sous rubrique CRUD
            {
                groupBoxRubrique.Width = 0;
                groupBoxSSRubrique.Width = 0;
                InitiatliserListeRubrique();
                buttonRubriqueModifier.Enabled = false;
                buttonRubriqueModifier.BackColor = Color.Peru;
                //buttonRubriqueSupprimer.Enabled = false;
                //buttonRubriqueSupprimer.BackColor = Color.Peru;

                buttonSSRubriqueModifier.Enabled = false;
                buttonSSRubriqueModifier.BackColor = Color.Peru;
                //buttonSSRubriqueSupprimer.Enabled = false;
                //buttonSSRubriqueSupprimer.BackColor = Color.Peru;
                groupBoxRubrique.Visible = false;
                groupBoxSSRubrique.Visible = false;
                textBoxRubrique.BackColor = Color.White;
                textBoxSSRubrique.BackColor = Color.White;
                valRubriqueNom = true;
                valSSRubriqueNom = true;
            }

        }
        public void MontrerBoutonsRub()
        {
            buttonRubriqueModifier.Visible = true;
            buttonRubriqueAjouter.Visible = true;
            comboBoxRubriqueListe1.Enabled = true;



        }
        public void MontrerBoutonsSSRub()
        {
            buttonSSRubriqueModifier.Visible = true;
            buttonSSRubriqueAjouter.Visible = true;
            comboBoxRubriqueListe2.Enabled = true;
            comboBoxSousRubriqueListe.Enabled = true;

        }

        public void RetrecirRub()
        {
            AnimationFermerGpBox(groupBoxRubrique);
        }
        public void RetrecirSSRub()
        {
            AnimationFermerGpBox(groupBoxSSRubrique);
        }

        public void InitiatliserListeRubrique()
        {
            //on remplit les 2 listes des rubriques dans les ComboBox.
            //Combo liste1
            comboBoxRubriqueListe1.ValueMember = "Id";
            comboBoxRubriqueListe1.DisplayMember = "Nom";
            RubriqueDAO ListeDesRubriques;
            ListeDesRubriques = new RubriqueDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxRubriqueListe1.DataSource = ListeDesRubriques.List();
            //combo liste2
            comboBoxRubriqueListe2.ValueMember = "Id";
            comboBoxRubriqueListe2.DisplayMember = "Nom";
            comboBoxRubriqueListe2.DataSource = ListeDesRubriques.List();
        }


        public void InitiatliserListeSousRubrique()
        {
            //on remplit la liste des sous rubriques
            comboBoxSousRubriqueListe.ValueMember = "Id";
            comboBoxSousRubriqueListe.DisplayMember = "Nom";
            SousRubriqueDAO ListeDesSousRubriques;
            ListeDesSousRubriques = new SousRubriqueDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxSousRubriqueListe.DataSource = ListeDesSousRubriques.ListSSparRub(Convert.ToInt32(comboBoxRubriqueListe2.SelectedValue.ToString()));
        }
        private void comboBoxRubriqueListe2_SelectedIndexChanged(object sender, EventArgs e)
        {

            InitiatliserListeSousRubrique();
        }

        private void comboBoxRubriqueListe1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRubriqueModifier.Enabled = true;
            //buttonRubriqueSupprimer.Enabled = true;
            buttonRubriqueModifier.BackColor = Color.Orange;
            //buttonRubriqueSupprimer.BackColor = Color.Orange;
        }

        private void comboBoxSousRubriqueListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSSRubriqueModifier.Enabled = true;
            //buttonSSRubriqueSupprimer.Enabled = true;
            buttonSSRubriqueModifier.BackColor = Color.Orange;
            //buttonSSRubriqueSupprimer.BackColor = Color.Orange;
        }
        public void CacherBoutonsRub()
        {
            buttonRubriqueAjouter.Visible = false;
            buttonRubriqueModifier.Visible = false;
            comboBoxRubriqueListe1.Enabled = false;

        }
        public void CacherBoutonsSSRub()
        {
            buttonSSRubriqueAjouter.Visible = false;
            buttonSSRubriqueModifier.Visible = false;
            comboBoxRubriqueListe2.Enabled = false;
            comboBoxSousRubriqueListe.Enabled = false;

        }

        private void buttonRubriqueAjouter_Click(object sender, EventArgs e)
        {
            groupBoxRubrique.Visible = true;
            AnimationOuvrirGpBox(groupBoxRubrique, 445);
            textBoxRubrique.Text = "";
            choixRubrique = 1;
            CacherBoutonsRub();
        }

        private void buttonRubriqueModifier_Click(object sender, EventArgs e)
        {

            groupBoxRubrique.Visible = true;
            AnimationOuvrirGpBox(groupBoxRubrique, 445);
            choixRubrique = 2;
            textBoxRubrique.Text = comboBoxRubriqueListe1.Text;
            CacherBoutonsRub();
        }

        private void buttonSSRubriqueAjouter_Click(object sender, EventArgs e)
        {
            groupBoxSSRubrique.Visible = true;
            AnimationOuvrirGpBox(groupBoxSSRubrique, 445);
            choixSSRubrique = 1;
            textBoxSSRubrique.Text = "";
            CacherBoutonsSSRub();

        }

        private void buttonSSRubriqueModifier_Click(object sender, EventArgs e)
        {
            groupBoxSSRubrique.Visible = true;
            AnimationOuvrirGpBox(groupBoxSSRubrique, 445);
            choixSSRubrique = 2;
            textBoxSSRubrique.Text = comboBoxSousRubriqueListe.Text;
            CacherBoutonsSSRub();
        }

        private void buttonRubriqueAnnuler_Click(object sender, EventArgs e)
        {
            AnimationFermerGpBox(groupBoxRubrique);
            MontrerBoutonsRub();
        }

        private void textBoxSSRubrique_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBoxSSRubrique.Text, @"[A-Z]+([a-z A-Z'éèîêâôûœïëüäö]{1,49})?$") == false) || (textBoxSSRubrique.Text == ""))
            {
                textBoxSSRubrique.BackColor = Color.Red;
                valSSRubriqueNom = false;
            }
            else
            {
                textBoxSSRubrique.BackColor = Color.White;
                valSSRubriqueNom = true;
            }
        }

        private void textBoxRubrique_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBoxRubrique.Text, @"[A-Z]+([a-z A-Z'éèîêâôûœïëüäö]{1,49})?$") == false) || (textBoxRubrique.Text == ""))
            {
                textBoxRubrique.BackColor = Color.Red;
                valRubriqueNom = false;
            }
            else
            {
                textBoxRubrique.BackColor = Color.White;
                valRubriqueNom = true;
            }
        }

        private void buttonSSRubriqueAnnuler_Click(object sender, EventArgs e)
        {
            AnimationFermerGpBox(groupBoxSSRubrique);
            MontrerBoutonsSSRub();
        }

        private void buttonRubriqueValider_Click(object sender, EventArgs e)
        {
            if (valRubriqueNom == true)
            {
                switch (choixRubrique)
                {
                    case 1:  //on a cliqué sur le bouton Ajouter
                        Rubrique NouveauRub = new Rubrique();
                        NouveauRub.Nom = textBoxRubrique.Text;
                        RubriqueDAO InsertionRub;
                        InsertionRub = new RubriqueDAO("server=.;database=villagegreen;Integrated Security = True");
                        try
                        {
                            InsertionRub.Insert(NouveauRub);
                            MessageBox.Show("INSERTION REUSSIE", "MESSAGE IMPORTANT");
                            InitiatliserListeRubrique();
                            RetrecirRub();
                            MontrerBoutonsRub();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("PROBLEME INSERTION NON REUSSIE ", "MESSAGE IMPORTANT");
                        }

                        break;
                    case 2:  //on a cliqué sur le bouton Modifier
                        Rubrique modRub = new Rubrique();
                        modRub.Nom = textBoxRubrique.Text;
                        modRub.Id = Convert.ToInt32(comboBoxRubriqueListe1.SelectedValue);
                        RubriqueDAO ModifRub;
                        ModifRub = new RubriqueDAO("server=.;database=villagegreen;Integrated Security = True");
                        try
                        {
                            ModifRub.Update(modRub);
                            MessageBox.Show("MODIFICATION REUSSIE", "MESSAGE IMPORTANT");
                            InitiatliserListeRubrique();
                            RetrecirRub();
                            MontrerBoutonsRub();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("PROBLEME MODIFICATION NON REUSSIE ", "MESSAGE IMPORTANT");
                        }
                        InitiatliserListeRubrique();
                        RetrecirRub();
                        MontrerBoutonsRub();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Erreur de saisie", "ATTENTION");
            }
        }

        private void buttonSSRubriqueValider_Click(object sender, EventArgs e)
        {
            if (valSSRubriqueNom == true)
            {
                switch (choixSSRubrique)
                {
                    case 1:  //on a cliqué sur le bouton Ajouter
                        SousRubrique NouveauSRub = new SousRubrique();
                        NouveauSRub.Id = Convert.ToInt32(comboBoxSousRubriqueListe.SelectedValue);
                        NouveauSRub.Nom = textBoxSSRubrique.Text;
                        NouveauSRub.SousRubriqueId = Convert.ToInt32(comboBoxRubriqueListe2.SelectedValue);
                        SousRubriqueDAO ModifSRub;
                        ModifSRub = new SousRubriqueDAO("server=.;database=villagegreen;Integrated Security = True");
                        try
                        {
                            ModifSRub.Insert(NouveauSRub);
                            MessageBox.Show("INSERTION REUSSIE", "MESSAGE IMPORTANT");
                            InitiatliserListeSousRubrique();
                            RetrecirSSRub();
                            MontrerBoutonsSSRub();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("PROBLEME INSERTION NON REUSSIE ", "MESSAGE IMPORTANT");
                        }
                        RetrecirSSRub();
                        MontrerBoutonsSSRub();
                        break;
                    case 2:  //on a cliqué sur le bouton Modifier
                        SousRubrique modSSRub = new SousRubrique();
                        modSSRub.Nom = textBoxSSRubrique.Text;
                        modSSRub.Id = Convert.ToInt32(comboBoxSousRubriqueListe.SelectedValue);
                        modSSRub.SousRubriqueId = Convert.ToInt32(comboBoxRubriqueListe2.SelectedValue);
                        SousRubriqueDAO ModifSSRub;
                        ModifSSRub = new SousRubriqueDAO("server=.;database=villagegreen;Integrated Security = True");
                        try
                        {
                            ModifSSRub.Update(modSSRub);
                            MessageBox.Show("MODIFICATION SOUS RUBRIQUE REUSSIE", "MESSAGE IMPORTANT");
                            InitiatliserListeSousRubrique();
                            RetrecirSSRub();
                            MontrerBoutonsSSRub();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("PROBLEME MODIFICATION NON REUSSIE ", "MESSAGE IMPORTANT");
                        }
                        InitiatliserListeSousRubrique();
                        RetrecirSSRub();
                        MontrerBoutonsSSRub();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Erreur de saisie", "ATTENTION");
            }
        }

        private void buttonProduitChercher_Click(object sender, EventArgs e)
        {
            valprixP = valminiP && valmaxiP;
            if (valprixP)
            {
                dataGridViewProduit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                int idprod, idrub, idssrub;
                bool etat = true, valid = true;
                double prixmax, prixmin;
                //initialiser les variables
                if (comboBoxProduitID.SelectedIndex >= 0)
                {
                    idprod = Convert.ToInt32(comboBoxProduitID.SelectedValue);
                    idrub = -1;
                    idssrub = -1;
                    prixmax = 0;
                    prixmin = 0;
                    etat = true;
                    valid = true;
                }
                else
                {
                    idprod = -1;
                    idrub = Convert.ToInt32(comboBoxProduitRub.SelectedValue);
                    idssrub = Convert.ToInt32(comboBoxProduitSSRub.SelectedValue);
                    if (radioButtonInactif.Checked)
                    {
                        etat = false;
                    }

                    if (radioButtonPasCatalogue.Checked)
                    {
                        valid = false;
                    }
                    prixmax = Convert.ToDouble(textBoxProduitPrixMax.Text);
                    prixmin = Convert.ToDouble(textBoxProduitPrixMini.Text);
                }




                //executer la requete de recherche
                ProduitDAO ListeDesProduits;
                ListeDesProduits = new ProduitDAO("server =.; database = villagegreen; Integrated Security = True");
                dataGridViewProduit.DataSource = ListeDesProduits.ListVariable(idprod, idrub, idssrub, etat, valid, prixmin, prixmax);
                dataGridViewProduit.Columns[0].HeaderText = "N° Produit";
                dataGridViewProduit.Columns[1].HeaderText = "Désignation";
                dataGridViewProduit.Columns[4].HeaderText = "Prix Vente";
                dataGridViewProduit.Columns[0].Width = 150;
                dataGridViewProduit.Columns[1].Width = 800;
                dataGridViewProduit.Columns[4].Width = 150;

                dataGridViewProduit.Columns[5].Visible = false;
                dataGridViewProduit.Columns[2].Visible = false;
                dataGridViewProduit.Columns[3].Visible = false;
                dataGridViewProduit.Columns[6].Visible = false;
                dataGridViewProduit.Columns[7].Visible = false;
                dataGridViewProduit.Columns[8].Visible = false;
                dataGridViewProduit.Columns[9].Visible = false;
                dataGridViewProduit.Columns[10].Visible = false;
                //dataGridViewProduit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Erreur de saisie", "ERREUR");
            }
        }

        private void comboBoxProduitRub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProduitRub.SelectedIndex != -1)
            {
                comboBoxProduitID.SelectedIndex = -1;
                initSSRubProduit();

            }
        }

        private void comboBoxProduitID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProduitID.SelectedIndex != -1)
            {
                comboBoxProduitRub.SelectedIndex = -1;
                comboBoxProduitSSRub.SelectedIndex = -1;
                textBoxProduitPrixMax.Text = Convert.ToString("0");
                textBoxProduitPrixMini.Text = Convert.ToString("0");
                radioButtonActif1.Checked = true;
                radioButtonCatalogue.Checked = true;


            }
        }

        private void comboBoxProduitSSRub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProduitSSRub.SelectedIndex != -1)
            {
                comboBoxProduitID.SelectedIndex = -1;

            }
        }

        private void textBoxProduitPrixMini_TextChanged(object sender, EventArgs e)
        {
            comboBoxProduitID.SelectedIndex = -1;
            if ((Regex.IsMatch(textBoxProduitPrixMini.Text, @"^[0-9]+(\.[0-9]+)?$") == false) || (textBoxProduitPrixMini.Text == ""))
            {
                textBoxProduitPrixMini.BackColor = Color.Red;
                valminiP = false;
                textBoxProduitPrixMini.Text = "0";
            }
            else
            {
                textBoxProduitPrixMini.BackColor = Color.White;
                valminiP = true;
            }
        }

        private void textBoxProduitPrixMax_TextChanged(object sender, EventArgs e)
        {
            comboBoxProduitID.SelectedIndex = -1;
            if ((Regex.IsMatch(textBoxProduitPrixMax.Text, @"^[0-9]+(\.[0-9]+)?$") == false) || (textBoxProduitPrixMax.Text == ""))
            {
                textBoxProduitPrixMax.BackColor = Color.Red;
                valmaxiP = false;
                textBoxProduitPrixMax.Text = "0";
            }
            else
            {
                textBoxProduitPrixMax.BackColor = Color.White;
                valmaxiP = true;
            }
        }

        private void radioButtonInactif_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxProduitID.SelectedIndex = -1;
        }

        private void radioButtonActif1_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxProduitID.SelectedIndex = -1;
        }

        private void radioButtonPasCatalogue_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxProduitID.SelectedIndex = -1;
        }

        private void radioButtonCatalogue_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxProduitID.SelectedIndex = -1;
        }



        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            textBoxNomFichier.Text = openFileDialog2.SafeFileName;
            pictureBoxProduit.ImageLocation = dossier2 + textBoxNomFichier.Text;

        }

        private void buttonAjouterPhoto_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();

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
            AnimationOuvrirGpBox(groupBoxFour, 500);
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

        private void buttonAjouterProduit_Click(object sender, EventArgs e)
        {
            choixprod = 1;
            pictureBoxProduit.ImageLocation = dossier2 + "0indisponible.jpg";
            textBoxNomFichier.Text = "0indisponible.jpg";
            panelProduit2.Visible = true;
            panelProduit2.Width = 0;
            textBoxProduitNomcourtAM.Text = "";
            textBoxProduitNomlongAM.Text = "";
            textBoxProduitNumAM.Text = "";
            textBoxProduitNumAM.Enabled = false;
            textBoxProduitPrixAchatAM.Text = "";
            textBoxProduitPrixVenteHTAM.Text = "";
            radioButtonProduitActifAM.Checked = true;
            radioButtonProduitPubAM.Checked = true;
            //on remplit la liste des rubriques
            comboBoxProduitRubriqueAM.ValueMember = "Id";
            comboBoxProduitRubriqueAM.DisplayMember = "Nom";
            RubriqueDAO ListeDesRubriques;
            ListeDesRubriques = new RubriqueDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxProduitRubriqueAM.DataSource = ListeDesRubriques.List();
            //on se place sur la bonne valeur dans la liste
            comboBoxProduitRubriqueAM.SelectedValue = 1;

            //on remplit la liste des sous rubrique
            comboBoxProduitSSRubriqueAM.ValueMember = "Id";
            comboBoxProduitSSRubriqueAM.DisplayMember = "Nom";
            SousRubriqueDAO ListeDesSousRubriques;
            ListeDesSousRubriques = new SousRubriqueDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxProduitSSRubriqueAM.DataSource = ListeDesSousRubriques.ListSSparRub(1);


            //on remplit la liste des tva
            comboBoxProduitTVAAM.ValueMember = "Id";
            comboBoxProduitTVAAM.DisplayMember = "Nom";
            TvaDAO listedesTva;
            listedesTva = new TvaDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxProduitTVAAM.DataSource = listedesTva.List();
            comboBoxProduitTVAAM.SelectedIndex = -1;
            // on remplit la liste des fournisseurs
            comboBoxProduitFournisseurAM.ValueMember = "Id";
            comboBoxProduitFournisseurAM.DisplayMember = "Nom";
            FournisseurDAO listedesFourn;
            listedesFourn = new FournisseurDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxProduitFournisseurAM.DataSource = listedesFourn.List();
            comboBoxProduitFournisseurAM.SelectedIndex = -1;



            AnimationOuvrirPanel(panelProduit2, 1190);



        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (P1.Width == TR1)
            {
                timer3.Stop();
            }
            else
            {
                P1.Width += 10;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            AnimationFermerPanel(panelProduit2);
            buttonModifier.Enabled = false;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (P1.Width == 0)
            {
                timer4.Stop();
                P1.Visible = false;
            }
            else
            {
                P1.Width -= 10;
            }
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            choixprod = 2;
            panelProduit2.Visible = true;
            panelProduit2.Width = 0;
            AnimationOuvrirPanel(panelProduit2, 1190);
            int num = Convert.ToInt32(dataGridViewProduit.SelectedCells[0].Value);
          
            //trouver les données du produit selectionné
            ProduitDAO trouveP;
            trouveP = new ProduitDAO("server =.; database = villagegreen; Integrated Security = True");
            Produit ProduitTrouve;
            ProduitTrouve = trouveP.Find(num);
            string idproduitP = Convert.ToString(ProduitTrouve.Id);
            string designationP = ProduitTrouve.NomLong;
            string nomcourtP = ProduitTrouve.NomCourt;
            string prixventehtP = Convert.ToString(ProduitTrouve.PrixVenteHT);
            string photoP = ProduitTrouve.Photo;
            string prixachatP = Convert.ToString(ProduitTrouve.PrixAchat);
            bool etatP = ProduitTrouve.Etat;
            bool validP = ProduitTrouve.Validite;
            int ssrubP = ProduitTrouve.IDSousRubrique;
            int fournisseurP = ProduitTrouve.IDFournisseur;
            int tvaP = ProduitTrouve.IDTVA;
            int rubP = ProduitTrouve.IDRubrique;

            // *************REMPLIR LA PAGE**************
            textBoxProduitNumAM.Text = idproduitP;
            textBoxProduitNomcourtAM.Text = nomcourtP;
            textBoxProduitNomlongAM.Text = designationP;
            //on remplit la liste des rubriques

            comboBoxProduitRubriqueAM.ValueMember = "Id";
            comboBoxProduitRubriqueAM.DisplayMember = "Nom";
            RubriqueDAO ListeDesRubriques;
            ListeDesRubriques = new RubriqueDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxProduitRubriqueAM.DataSource = ListeDesRubriques.List();
            //on se place sur la bonne valeur dans la liste
            comboBoxProduitRubriqueAM.SelectedValue = rubP;

            //on remplit la liste des sous rubrique
            comboBoxProduitSSRubriqueAM.ValueMember = "Id";
            comboBoxProduitSSRubriqueAM.DisplayMember = "Nom";
            SousRubriqueDAO ListeDesSousRubriques;
            ListeDesSousRubriques = new SousRubriqueDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxProduitSSRubriqueAM.DataSource = ListeDesSousRubriques.ListSSparRub(rubP);
            //on se place sur la bonne valeur dans la liste
            comboBoxProduitSSRubriqueAM.SelectedValue = ssrubP;
            //on remplit la liste des tva
            comboBoxProduitTVAAM.ValueMember = "Id";
            comboBoxProduitTVAAM.DisplayMember = "Nom";
            TvaDAO listedesTva;
            listedesTva = new TvaDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxProduitTVAAM.DataSource = listedesTva.List();

            // on remplit la liste des fournisseurs
            comboBoxProduitFournisseurAM.ValueMember = "Id";
            comboBoxProduitFournisseurAM.DisplayMember = "Nom";
            FournisseurDAO listedesFourn;
            listedesFourn = new FournisseurDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxProduitFournisseurAM.DataSource = listedesFourn.List();

            // on place les selection dans les combos tva,rubrique et sous rubrique
            pictureBoxProduit.ImageLocation = dossier2 + textBoxNomFichier.Text;
            textBoxNomFichier.Text = photoP;
            textBoxProduitPrixVenteHTAM.Text = prixventehtP;
            textBoxProduitPrixAchatAM.Text = prixachatP;

            comboBoxProduitTVAAM.SelectedValue = tvaP;
            //comboBoxProduitRubriqueAM.SelectedValue = rubP;
            //comboBoxProduitSSRubriqueAM.SelectedValue = ssrubP;
            comboBoxProduitFournisseurAM.SelectedValue = fournisseurP;
            if (etatP)
            {
                radioButtonProduitActifAM.Checked = true;
            }
            else
            {
                radioButtonProduitInactifAM.Checked = true;
            }
            if (validP)
            {
                radioButtonProduitPubAM.Checked = true;
            }
            else
            {
                radioButtonProduitNonPubAM.Checked = true;
            }

        }

        private void button27_Click(object sender, EventArgs e)
        {

            validiteP = valNomCourtP && valNomLongP && validrubP && validssrubP && validtvaP && validfourP && valEtatP && valvalidP;
            if (validiteP)
            {
                switch (choixprod)
                {
                    case 1:

                        Produit NouveauInser = new Produit();

                        NouveauInser.NomLong = textBoxProduitNomlongAM.Text;
                        NouveauInser.NomCourt = textBoxProduitNomcourtAM.Text;
                        NouveauInser.PrixAchat = Convert.ToDouble(textBoxProduitPrixAchatAM.Text);
                        NouveauInser.PrixVenteHT = Convert.ToDouble(textBoxProduitPrixVenteHTAM.Text);
                        NouveauInser.IDTVA = Convert.ToInt32(comboBoxProduitTVAAM.SelectedValue);
                        NouveauInser.IDSousRubrique = Convert.ToInt32(comboBoxProduitSSRubriqueAM.SelectedValue);
                        NouveauInser.IDFournisseur = Convert.ToInt32(comboBoxProduitFournisseurAM.SelectedValue);

                        if (radioButtonProduitActifAM.Checked)
                        {
                            NouveauInser.Etat = true;
                        }
                        else
                        {
                            NouveauInser.Etat = false;
                        }
                        if (radioButtonProduitPubAM.Checked)
                        {
                            NouveauInser.Validite = true;
                        }
                        else
                        {
                            NouveauInser.Validite = false;
                        }

                        NouveauInser.Photo = textBoxNomFichier.Text;
                        ProduitDAO Insertion;
                        Insertion = new ProduitDAO("server=.;database=villagegreen;Integrated Security = True");
                        try
                        {
                            Insertion.Insert(NouveauInser);
                            MessageBox.Show("INSERTION REUSSIE", "MESSAGE IMPORTANT");
                            AnimationFermerPanel(panelProduit2);
                            buttonModifier.Enabled = false;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("PROBLEME INSERTION NON REUSSIE ", "MESSAGE IMPORTANT");
                        }

                        break;
                    case 2:

                        Produit NouveauMod = new Produit();
                        NouveauMod.Id = Convert.ToInt32(textBoxProduitNumAM.Text);
                        NouveauMod.NomLong = textBoxProduitNomlongAM.Text;
                        NouveauMod.NomCourt = textBoxProduitNomcourtAM.Text;
                        NouveauMod.PrixAchat = Convert.ToDouble(textBoxProduitPrixAchatAM.Text);
                        NouveauMod.PrixVenteHT = Convert.ToDouble(textBoxProduitPrixVenteHTAM.Text);
                        NouveauMod.IDTVA = Convert.ToInt32(comboBoxProduitTVAAM.SelectedValue);
                        NouveauMod.IDSousRubrique = Convert.ToInt32(comboBoxProduitSSRubriqueAM.SelectedValue);
                        NouveauMod.IDFournisseur = Convert.ToInt32(comboBoxProduitFournisseurAM.SelectedValue);
                        if (radioButtonProduitActifAM.Checked)
                        {
                            NouveauMod.Etat = true;
                        }
                        else
                        {
                            NouveauMod.Etat = false;
                        }
                        if (radioButtonProduitPubAM.Checked)
                        {
                            NouveauMod.Validite = true;
                        }
                        else
                        {
                            NouveauMod.Validite = false;
                        }

                        NouveauMod.Photo = textBoxNomFichier.Text;

                        ProduitDAO ModifProd;
                        ModifProd = new ProduitDAO("server=.;database=villagegreen;Integrated Security = True");
                        try
                        {
                            ModifProd.Update(NouveauMod);
                            MessageBox.Show("MODIFICATION REUSSIE", "MESSAGE IMPORTANT");
                            AnimationFermerPanel(panelProduit2);
                            buttonModifier.Enabled = false;

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("PROBLEME MODIFICATION NON REUSSIE ", "MESSAGE IMPORTANT");
                        }

                        break;

                }
                
            }
            else
                {
                MessageBox.Show("Tous les champs ne sont pas valides \n Veuillez corriger ou annuler", "ERREUR");
                }

        }
        public void listeFonctions()
        {
            comboBoxUtilFonc.Items.Add("Administrateur");
            comboBoxUtilFonc.Items.Add("Client");
            comboBoxUtilFonc.Items.Add("Commercial");
            comboBoxUtilFonc.Items.Add("Gestionnaire");
           

        }

      

        private void Form2_Load(object sender, EventArgs e)
        {
            listeFonctions();
        }

        private void textBoxNomFichier_TextChanged(object sender, EventArgs e)
        {
            pictureBoxProduit.ImageLocation = dossier2 + textBoxNomFichier.Text;
        }

        private void textBoxProduitPrixVenteHTAM_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBoxProduitPrixVenteHTAM.Text, @"^[0-9]+(\.[0-9]+)?$") == false) || (textBoxProduitPrixVenteHTAM.Text == ""))
            {
                textBoxProduitPrixVenteHTAM.BackColor = Color.Red;
                valvalidP = false;
            }
            else
            {
                textBoxProduitPrixVenteHTAM.BackColor = Color.White;
                valvalidP = true;
            }
        }

        private void comboBoxProduitFournisseurAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProduitFournisseurAM.SelectedIndex == -1)
            {
                validfourP = false;
                comboBoxProduitFournisseurAM.BackColor = Color.Red;
            }
            else
            {
                validfourP = true;
                comboBoxProduitFournisseurAM.BackColor = Color.White;
            }

        }

        private void textBoxProduitPrixAchatAM_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBoxProduitPrixAchatAM.Text, @"^[0-9]+(\.[0-9]+)?$") == false) || (textBoxProduitPrixAchatAM.Text == ""))
            {
                textBoxProduitPrixAchatAM.BackColor = Color.Red;
                valEtatP = false;
            }
            else
            {
                textBoxProduitPrixAchatAM.BackColor = Color.White;
                valEtatP = true;
            }
        }

        private void comboBoxProduitRubriqueAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProduitRubriqueAM.SelectedIndex == -1)
            {
                validrubP = false;
                comboBoxProduitRubriqueAM.BackColor = Color.Red;
            }
            else
            {
                validrubP = true;
                comboBoxProduitRubriqueAM.BackColor = Color.White;
            }
            //on actualise la liste des sous rubrique
            comboBoxProduitSSRubriqueAM.ValueMember = "Id";
            comboBoxProduitSSRubriqueAM.DisplayMember = "Nom";
            SousRubriqueDAO ListeDesSousRubriques;
            ListeDesSousRubriques = new SousRubriqueDAO("server =.; database = villagegreen; Integrated Security = True");
            comboBoxProduitSSRubriqueAM.DataSource = ListeDesSousRubriques.ListSSparRub(Convert.ToInt32(comboBoxProduitRubriqueAM.SelectedValue));
        }

        private void comboBoxProduitTVAAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProduitTVAAM.SelectedIndex == -1)
            {
                validtvaP = false;
                comboBoxProduitTVAAM.BackColor = Color.Red;
            }
            else
            {
                validtvaP = true;
                comboBoxProduitTVAAM.BackColor = Color.White;
            }
        }

        private void comboBoxProduitSSRubriqueAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProduitSSRubriqueAM.SelectedIndex == -1)
            {
                validssrubP = false;
                comboBoxProduitSSRubriqueAM.BackColor = Color.Red;
            }
            else
            {
                validssrubP = true;
                comboBoxProduitSSRubriqueAM.BackColor = Color.White;
            }
        }

        private void dataGridViewProduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonModifier.Enabled = true;
        }

        private void textBoxProduitNomlongAM_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBoxProduitNomlongAM.Text, @"^[A-Z a-z0-9éèîêâô.ûœïëüäö_-]{1,100}$") == false) || (textBoxProduitNomlongAM.Text == ""))
            {
                textBoxProduitNomlongAM.BackColor = Color.Red;
                valNomLongP = false;
            }
            else
            {
                textBoxProduitNomlongAM.BackColor = Color.White;
                valNomLongP = true;
            }
        }



        private void textBoxProduitNomcourtAM_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBoxProduitNomcourtAM.Text, @"^[A-Z a-z0-9éèîêâôû.œïëüäö_-]{1,10}$") == false) || (textBoxProduitNomcourtAM.Text == ""))
            {
                textBoxProduitNomcourtAM.BackColor = Color.Red;
                valNomCourtP = false;
            }
            else
            {
                textBoxProduitNomcourtAM.BackColor = Color.White;
                valNomCourtP = true;
            }
        }

        private void textBoxFourNom_TextChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(textBoxFourNom.Text, @"^[A-Z]+([a-z A-Z'éèîêâôûœïëüäö]{1,49})?$") == false) || (textBoxFourNom.Text == ""))
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

        public void AnimationOuvrirPanel(Panel panelrecu, int taillerecu)
        {

            P1 = panelrecu;
            TR1 = taillerecu;
            timer3.Start();
        }
        public void AnimationFermerPanel(Panel panelrecu)
        {
            P1 = panelrecu;
            timer4.Start();
        }

        public void AnimationOuvrirGpBox(GroupBox grouperecu, int taillerecu)
        {

            GB1 = grouperecu;
            TR1 = taillerecu;
            timer1.Start();
        }
        public void AnimationFermerGpBox(GroupBox grouperecu)
        {
            GB1 = grouperecu;
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GB1.Width == TR1)
            {
                timer1.Stop();
            }
            else
            {
                GB1.Width += 5;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (GB1.Width == 0)
            {
                timer2.Stop();
                GB1.Visible = false;
            }
            else
            {
                GB1.Width -= 5;
            }
        }
    }
}
