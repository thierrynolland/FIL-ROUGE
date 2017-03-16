using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class CAFournisseurDAO
    {
        SqlConnection MaConnexion;
        public CAFournisseurDAO(string chainedeconnection)
        {
            MaConnexion = new SqlConnection(chainedeconnection);
        }
        public List<CAFournisseur> ListCAFour()
        {
            MaConnexion.Open();
            List<CAFournisseur> resultat = new List<CAFournisseur>();
            SqlCommand requete = new SqlCommand("select fournisseur.fournisseur_id, fournisseur.fournisseur_nom, sum(lignecom_qte*prix_fixe) as total from ligne_de_commande JOIN PRODUIT ON  ligne_de_commande.produit_id = produit.produit_id JOIN FOURNISSEUR ON  produit.fournisseur_id = fournisseur.fournisseur_id group by fournisseur.fournisseur_id, fournisseur.fournisseur_nom", MaConnexion);
            SqlDataReader lecture = requete.ExecuteReader();
            while (lecture.Read())
            {
                CAFournisseur f = new CAFournisseur();
                f.Id = Convert.ToInt32(lecture["fournisseur_id"]);
                f.Nom = Convert.ToString(lecture["fournisseur_nom"]);
                f.CA = Convert.ToString(lecture["total"]);
                resultat.Add(f);
            }
            lecture.Close();
            MaConnexion.Close();
            return resultat;
        }
    }
}
