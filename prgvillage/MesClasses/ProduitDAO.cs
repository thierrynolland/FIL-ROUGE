using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class ProduitDAO
    {
        SqlConnection MaConnexion;
        public ProduitDAO(string chainedeconnection)
        {
            MaConnexion = new SqlConnection(chainedeconnection);
        }
        public void Insert(Produit prod)
        {
            MaConnexion.Open();
            SqlCommand requete1 = new SqlCommand("insert into produit (produit_nomcourt,produit_nom,produit_photo,produit_prixachat,produit_etat,produit_prixht,produit_validite,ss_rubrique_id,fournisseur_id,tva_id) values (@NomCourt, @NomLong, @Photo, @PrixAchat, @Etat, @PrixVenteHT, @Validite, @IDSousRubrique,@IDFournisseur,@IDTVA)", MaConnexion);
            requete1.Parameters.AddWithValue("@NomCourt", prod.NomCourt);
            requete1.Parameters.AddWithValue("@NomLong", prod.NomLong);
            requete1.Parameters.AddWithValue("@Photo", prod.Photo);
            requete1.Parameters.AddWithValue("@PrixAchat", prod.PrixAchat);
            requete1.Parameters.AddWithValue("@Etat", prod.Etat);
            requete1.Parameters.AddWithValue("@PrixVenteHT", prod.PrixVenteHT);
            requete1.Parameters.AddWithValue("@Validite", prod.Validite);
            requete1.Parameters.AddWithValue("@IDSousRubrique", prod.IDSousRubrique);
            requete1.Parameters.AddWithValue("@IDFournisseur", prod.IDFournisseur);
            requete1.Parameters.AddWithValue("@IDTVA", prod.IDTVA);
            requete1.ExecuteNonQuery();
            MaConnexion.Close();
        }
        public void Update(Produit prod)
        {
            MaConnexion.Open();
            SqlCommand requete3 = new SqlCommand("update produit set produit_nomcourt=@NomCourt,produit_nom=@NomLong,produit_photo=@Photo,produit_prixachat=@PrixAchat,produit_etat=@Etat,produit_prixht=@PrixVenteHT,produit_validite=@Validite,ss_rubrique_id=@IDSousRubrique,fournisseur_id=@IDFournisseur,tva_id=@IDTVA where produit_id=@Id", MaConnexion);
            requete3.Parameters.AddWithValue("@Id", prod.Id);
            requete3.Parameters.AddWithValue("@NomCourt", prod.NomCourt);
            requete3.Parameters.AddWithValue("@NomLong", prod.NomLong);
            requete3.Parameters.AddWithValue("@Photo", prod.Photo);
            requete3.Parameters.AddWithValue("@PrixAchat", prod.PrixAchat);
            requete3.Parameters.AddWithValue("@Etat", prod.Etat);
            requete3.Parameters.AddWithValue("@PrixVenteHT", prod.PrixVenteHT);
            requete3.Parameters.AddWithValue("@Validite", prod.Validite);
            requete3.Parameters.AddWithValue("@IDSousRubrique", prod.IDSousRubrique);
            requete3.Parameters.AddWithValue("@IDFournisseur", prod.IDFournisseur);
            requete3.Parameters.AddWithValue("@IDTVA", prod.IDTVA);
            requete3.ExecuteNonQuery();
            MaConnexion.Close();

        }

        public Produit Find(int id)
        {
            MaConnexion.Open();
            //SqlCommand requete5 = new SqlCommand("Select * from produit where produit_id=@id", MaConnexion);
            SqlCommand requete5 = new SqlCommand("Select * from produit join sous_rubrique on sous_rubrique.ss_rubrique_id = produit.ss_rubrique_id join rubrique on rubrique.rubrique_id = sous_rubrique.rubrique_id where produit_id = @id", MaConnexion);
            requete5.Parameters.AddWithValue("@id", id);
            SqlDataReader lecture = requete5.ExecuteReader();
            lecture.Read();
            Produit NouveauProduit = new Produit();
            NouveauProduit.Id = Convert.ToInt32(lecture["produit_id"]);
            NouveauProduit.NomCourt = lecture["produit_nomcourt"].ToString();
            NouveauProduit.NomLong = lecture["produit_nom"].ToString();
            NouveauProduit.Photo = lecture["produit_photo"].ToString();
            NouveauProduit.PrixAchat = Convert.ToDouble(lecture["produit_prixachat"]);
            NouveauProduit.Etat = Convert.ToBoolean(lecture["produit_etat"]);
            NouveauProduit.PrixVenteHT = Convert.ToDouble(lecture["produit_prixht"]);
            NouveauProduit.Validite = Convert.ToBoolean(lecture["produit_validite"]);
            NouveauProduit.IDSousRubrique = Convert.ToInt32(lecture["ss_rubrique_id"]);
            NouveauProduit.IDRubrique = Convert.ToInt32(lecture["rubrique_id"]);
            NouveauProduit.IDFournisseur = Convert.ToInt32(lecture["fournisseur_id"]);
            NouveauProduit.IDTVA = Convert.ToInt32(lecture["tva_id"]);
            lecture.Close();
            MaConnexion.Close();
            return NouveauProduit;
        }

        public List<Produit> List()
        {
            MaConnexion.Open();
            List<Produit> resultat = new List<Produit>();
            //SqlCommand requete = new SqlCommand("select * from produit", MaConnexion);
            SqlCommand requete = new SqlCommand("Select * from produit join sous_rubrique on sous_rubrique.ss_rubrique_id = produit.ss_rubrique_id join rubrique on rubrique.rubrique_id = sous_rubrique.rubrique_id", MaConnexion);

            SqlDataReader lecture = requete.ExecuteReader();
            while (lecture.Read())
            {
                Produit p = new Produit();
                p.Id = Convert.ToInt32(lecture["produit_id"]);
                p.NomCourt = lecture["produit_nomcourt"].ToString();
                p.NomLong = lecture["produit_nom"].ToString();
                p.Photo = lecture["produit_photo"].ToString();
                p.PrixAchat = Convert.ToDouble(lecture["produit_prixachat"]);
                p.Etat = Convert.ToBoolean(lecture["produit_etat"]);
                p.PrixVenteHT = Convert.ToDouble(lecture["produit_prixht"]);
                p.Validite = Convert.ToBoolean(lecture["produit_validite"]);
                p.IDSousRubrique = Convert.ToInt32(lecture["ss_rubrique_id"]);
                p.IDRubrique = Convert.ToInt32(lecture["ss_rubrique_id"]);
                p.IDFournisseur = Convert.ToInt32(lecture["fournisseur_id"]);
                p.IDTVA = Convert.ToInt32(lecture["tva_id"]);

                resultat.Add(p);
            }
            lecture.Close();
            MaConnexion.Close();
            return resultat;
        }
        public List<Produit> ListVariable(int id, int rub, int ssrub, bool etat, bool pub, double prixmin, double prixmax)
        {
            string requetecompose = "select produit.produit_id as Numero,produit.produit_nom as Désignation, produit.produit_prixht as PrixHT, produit.produit_photo as Photo, produit.produit_nomcourt as Nomcourt,produit.produit_prixachat as PrixAchat,produit.produit_etat as Etat,produit.produit_validite as Validite,produit.ss_rubrique_id  as SSrubrique,produit.fournisseur_id as Fournisseur,produit.tva_id as Tva, rubrique.rubrique_id as Rubrique from produit join sous_rubrique on produit.ss_rubrique_id = sous_rubrique.ss_rubrique_id join rubrique on rubrique.rubrique_id = sous_rubrique.rubrique_id where produit.produit_id>0 ";
            MaConnexion.Open();
            if (id >= 0)
            {
                requetecompose = requetecompose + " and produit.produit_id=@Produit_id ";
            }
            else
            {


                if (rub != 0)
                {
                    requetecompose = requetecompose + " and rubrique.rubrique_id=@Rubrique_id ";
                }
                if (ssrub != 0)
                {
                    requetecompose = requetecompose + " and sous_rubrique.ss_rubrique_id=@SSRubrique_id ";
                }
                if (etat)
                {
                    requetecompose = requetecompose + " and produit.produit_etat=@ProduitEtat ";
                }
                if (pub)
                {
                    requetecompose = requetecompose + " and produit.produit_validite=@ProduitValidite ";
                }
                if (prixmax != 0)
                {
                    requetecompose = requetecompose + " and produit_prixht<@ProduitPMax ";
                }
                if (prixmin != 0)
                {
                    requetecompose = requetecompose + " and produit_prixht>@ProduitPMin ";
                }
            }
            

            List<Produit> resultat = new List<Produit>();
            SqlCommand requete6 = new SqlCommand(requetecompose, MaConnexion);
            requete6.Parameters.AddWithValue("@Produit_id", id);
            requete6.Parameters.AddWithValue("@Rubrique_id", rub);
            requete6.Parameters.AddWithValue("@SSRubrique_id", ssrub);
            requete6.Parameters.AddWithValue("@ProduitEtat", etat);
            requete6.Parameters.AddWithValue("@ProduitValidite", pub);
            requete6.Parameters.AddWithValue("@ProduitPMax", prixmax);
            requete6.Parameters.AddWithValue("@ProduitPMin", prixmin);
            SqlDataReader lecture = requete6.ExecuteReader();
            while (lecture.Read())
            {
                Produit p = new Produit();
                p.Id = Convert.ToInt32(lecture["numero"]);
                p.NomCourt = lecture["Nomcourt"].ToString();
                p.NomLong = lecture["Désignation"].ToString();
                p.Photo = lecture["Photo"].ToString();
                p.PrixAchat = Convert.ToDouble(lecture["PrixAchat"]);
                p.Etat = Convert.ToBoolean(lecture["Etat"]);
                p.PrixVenteHT = Convert.ToDouble(lecture["PrixHT"]);
                p.Validite = Convert.ToBoolean(lecture["Validite"]);
                p.IDSousRubrique = Convert.ToInt32(lecture["SSrubrique"]);
                p.IDFournisseur = Convert.ToInt32(lecture["Fournisseur"]);
                p.IDTVA = Convert.ToInt32(lecture["Tva"]);
                p.IDRubrique = Convert.ToInt32(lecture["Rubrique"]);

                resultat.Add(p);
            }
            lecture.Close();
            MaConnexion.Close();
            return resultat;
        }


    }
}
