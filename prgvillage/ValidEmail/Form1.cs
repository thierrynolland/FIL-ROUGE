using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidEmail
{
    public partial class Form1 : Form
    {
        string email = "";
        string erreur;
        bool erreurReg = false;
        public Form1()
        {
            InitializeComponent();
        }

        public static string verifEmail(string texte)
        {
            //bool erreurRE = false;
            int longueur = texte.Length;
            string chaine = "";
            if (Regex.IsMatch(texte, @"^[a-zA-Z0-9._-]{2,}@[a-z0-9._-]{2,}\.[a-zA-Z]{2,4}$") == false)
            {
                //si c'est faux
                //textBoxEmail.BackColor = Color.Red;

                //erreurRE = true;
                // verif @
                int positionArobase = texte.IndexOf("@");
                int positionPoint = texte.IndexOf(".");
                if (positionPoint == -1)
                {
                    chaine += "- Il manque le point \n";
                }
                if (positionArobase == -1)
                {
                    chaine += "- Il manque  @ \n";
                }
                else
                {
                    if (positionArobase < 2)
                    {
                        chaine += "pas assez de caractères avant le @ \n";
                    }
                }

                int positionPoint2 = 0;
                if ((positionPoint > -1) && (positionArobase > -1))
                {
                    positionPoint2 = texte.IndexOf(".", positionArobase);
                    if (positionPoint2 > -1)
                    {
                        int dif = 0;
                        dif = positionPoint2 - positionArobase;
                        if (dif < 3)
                        {
                            chaine += "pas assez de caractères entre @ et le point \n";
                        }
                        //else
                        //{
                            int compt2 = 0;
                            for (int j=positionPoint2;j<longueur;j++)
                            {
                                compt2++;
                            }
                            if (compt2<3)
                            {
                                chaine += " pas assez de caractères après le point \n";
                            }
                        //}

                    }
                    else
                    {
                        chaine += " aucun point après le @ \n";
                    }
                }


            }

            else
            {
                //erreurRE = false;
                chaine = "";
            }


            return chaine;
        }


        

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z0-9._-]{2,}@[a-z0-9._-]{2,}\.[a-zA-Z]{2,4}$") == false)

        {
            textBoxEmail.BackColor = Color.Red;
            erreurReg = true;
        }
        else
        {
            textBoxEmail.BackColor = Color.White;
            erreurReg = false;
        }

    }

    private void ButtonValider_Click(object sender, EventArgs e)
    {
        email = textBoxEmail.Text;
        erreur = verifEmail(email);
        //Console.WriteLine(erreur);
        if (erreur!="")
            {
                MessageBox.Show(erreur, "erreur");
            }
        

    }
}
}
