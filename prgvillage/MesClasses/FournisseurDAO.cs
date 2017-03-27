using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class FournisseurDAO
    {
        SqlConnection MaConnexion;
        public FournisseurDAO(string chainedeconnection)
        {
            MaConnexion = new SqlConnection(chainedeconnection);
        }

        public void Insert(Fournisseur four)
        {
            MaConnexion.Open();
            SqlCommand requete1 = new SqlCommand("insert into fournisseur (fournisseur_nom,fournisseur_adresse,fournisseur_cp,fournisseur_ville) values (@nom,@adresse,@cp,@ville)", MaConnexion);
            requete1.Parameters.AddWithValue("@nom", four.Nom);
            requete1.Parameters.AddWithValue("@adresse", four.Adresse);
            requete1.Parameters.AddWithValue("@cp", four.CP);
            requete1.Parameters.AddWithValue("@ville", four.Ville);
            requete1.ExecuteNonQuery();
            MaConnexion.Close();
        }

        public void Update(Fournisseur four)
        {
            MaConnexion.Open();
            SqlCommand requete3 = new SqlCommand("update fournisseur set fournisseur_nom=@nom,fournisseur_adresse=@adresse,fournisseur_cp=@cp,fournisseur_ville=@ville from fournisseur where fournisseur_id = @id", MaConnexion);
            requete3.Parameters.AddWithValue("@id", four.Id);
            requete3.Parameters.AddWithValue("@nom", four.Nom);
            requete3.Parameters.AddWithValue("@adresse", four.Adresse);
            requete3.Parameters.AddWithValue("@cp", four.CP);
            requete3.Parameters.AddWithValue("@ville", four.Ville);
            requete3.ExecuteNonQuery();
            MaConnexion.Close();

        }

        public void Delete(Fournisseur four)
        {
            MaConnexion.Open();
            SqlCommand requete4 = new SqlCommand("delete from fournisseur where fournisseur_id = @id", MaConnexion);
            requete4.Parameters.AddWithValue("@id", four.Id);
            requete4.ExecuteNonQuery();
            MaConnexion.Close();
        }

        public Fournisseur Find(int id)
        {
            MaConnexion.Open();
            SqlCommand requete5 = new SqlCommand("Select * from fournisseur where fournisseur_id=@id", MaConnexion);
            requete5.Parameters.AddWithValue("@id", id);
            SqlDataReader resultat = requete5.ExecuteReader();
            resultat.Read();
            Fournisseur NouveauFournisseur = new Fournisseur();
            NouveauFournisseur.Id = Convert.ToInt32(resultat["fournisseur_id"].ToString());
            NouveauFournisseur.Nom = resultat["fournisseur_nom"].ToString();
            NouveauFournisseur.Adresse = resultat["fournisseur_adresse"].ToString();
            NouveauFournisseur.CP = resultat["fournisseur_cp"].ToString();
            NouveauFournisseur.Ville = resultat["fournisseur_ville"].ToString();
            resultat.Close();
            MaConnexion.Close();

            return NouveauFournisseur;
        }
        public List<Fournisseur> List()
        {
            MaConnexion.Open();
            List<Fournisseur> resultat = new List<Fournisseur>();
            SqlCommand requete = new SqlCommand("select * from fournisseur", MaConnexion);

            SqlDataReader lecture = requete.ExecuteReader();
            while (lecture.Read())
            {
                Fournisseur f = new Fournisseur();
                f.Id = Convert.ToInt32(lecture["fournisseur_id"]);
                f.Nom = Convert.ToString(lecture["fournisseur_nom"]);
                f.Adresse = Convert.ToString(lecture["fournisseur_adresse"]);
                f.CP = Convert.ToString(lecture["fournisseur_cp"]);
                f.Ville = Convert.ToString(lecture["fournisseur_ville"]);
                resultat.Add(f);
            }
            lecture.Close();
            MaConnexion.Close();
            return resultat;
        }
        public double TrouverCATotalFournisseur()
        {
            double CATotalFour=0;
            MaConnexion.Open();
            SqlCommand requete6 = new SqlCommand("select sum(lignecom_qte*prix_fixe) As 'CAHTTotal' from ligne_de_commande", MaConnexion);
            SqlDataReader resultat = requete6.ExecuteReader();
            resultat.Read();
            CATotalFour= Convert.ToDouble(resultat["CAHTTotal"].ToString());
            resultat.Close();
            MaConnexion.Close();
            return CATotalFour;
        }
        public double TrouverCAFournisseur(int id)
        {
            double CAFour = 0;
            MaConnexion.Open();
            SqlCommand requete7 = new SqlCommand("select fournisseur.fournisseur_id, sum(lignecom_qte*prix_fixe) as 'total' from ligne_de_commande JOIN	PRODUIT ON	ligne_de_commande.produit_id = produit.produit_id JOIN	FOURNISSEUR	ON	produit.fournisseur_id=fournisseur.fournisseur_id where fournisseur.fournisseur_id=@id group by fournisseur.fournisseur_id", MaConnexion);
            requete7.Parameters.AddWithValue("@id", id);
            SqlDataReader resultat = requete7.ExecuteReader();
            if (resultat.Read())
            {
                CAFour = Convert.ToDouble(resultat["total"].ToString());
            }
            resultat.Close();
            MaConnexion.Close();
            return CAFour;
        }
        public double ListCAFournisseur(int id)
        {
            double CAFour = 0;
            MaConnexion.Open();
            SqlCommand requete7 = new SqlCommand("select fournisseur.fournisseur_id, sum(lignecom_qte*prix_fixe) as 'total' from ligne_de_commande JOIN	PRODUIT ON	ligne_de_commande.produit_id = produit.produit_id JOIN	FOURNISSEUR	ON	produit.fournisseur_id=fournisseur.fournisseur_id where fournisseur.fournisseur_id=@id group by fournisseur.fournisseur_id", MaConnexion);
            requete7.Parameters.AddWithValue("@id", id);
            SqlDataReader resultat = requete7.ExecuteReader();
            if (resultat.Read())
            {
                CAFour = Convert.ToDouble(resultat["total"].ToString());
            }
            resultat.Close();
            MaConnexion.Close();
            return CAFour;


        }

    }
}
