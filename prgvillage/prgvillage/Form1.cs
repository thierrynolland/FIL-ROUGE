using MesClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prgvillage
{

    public partial class Form1 : Form
    {

        public string identifiant="";
        public string mdp = "";
        public bool entrer = false;
        public bool connecter = false;
        public string MotPasseUtil;
        public string IdUtil;
        string EmailUtil;
        DateTime DateInscUtil;
        bool ConfirmUtil;
        string TypeUtil;
        int IdPersoUtil;
        string NomUtil;
        string PrenomUtil;


        public Form1()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            connecter = false;
            entrer = false;
            //trouver l'identifiant de connexion
                identifiant = textBoxID.Text;
                mdp = textBoxMDP.Text;
                try
                {
                    UtilisateurDAO trouveU;
                    trouveU = new UtilisateurDAO("server =.; database = villagegreen; Integrated Security = True");
                    Utilisateur Util;
                    Util = trouveU.Find(identifiant);
                    IdUtil = Util.Id;
                    MotPasseUtil = Util.MotDePasse;
                    EmailUtil = Util.Email;
                    DateInscUtil = Util.DateInscription;
                    ConfirmUtil = Util.Confirm;
                    TypeUtil = Util.Type;
                    IdPersoUtil = Util.Idperso;
                    NomUtil = Util.Nom;
                    PrenomUtil = Util.Prenom;
                    connecter = true;
                    textBoxID.BackColor = Color.White;
                }
                catch (Exception)
                {
                    MessageBox.Show("PROBLEME Identifiant Inexistant", "MESSAGE IMPORTANT");
                    connecter = false;
                    textBoxID.BackColor = Color.Red;
                
            }
                if (connecter == true)
                {
                    //Vérifier la concordance avec mot de passe
                    if (MotPasseUtil == mdp)
                    {
                       textBoxMDP.BackColor = Color.White;
                       entrer = true;
                        Form2 f = new Form2();
                        f.Show();
                    

                    }
                    else
                    {
                    entrer = false;
                    MessageBox.Show("PROBLEME Mot De Passe Faux ou Inexistant", "MESSAGE IMPORTANT");
                    textBoxMDP.BackColor = Color.Red;
                    }
                }
     
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation= Application.StartupPath + @"\images\logovillagegreen.PNG";
        }
    }
}
