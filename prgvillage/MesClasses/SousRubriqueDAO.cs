﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class SousRubriqueDAO
    {
        SqlConnection MaConnexion;
        public SousRubriqueDAO(string chainedeconnection)
        {
            MaConnexion = new SqlConnection(chainedeconnection);
        }
        public void Insert(SousRubrique ssrub)
        {
            MaConnexion.Open();
            SqlCommand requete1 = new SqlCommand("insert into sous_rubrique (ss_rubrique_nom,rubrique_id) values (@nom,@rubriqueID)", MaConnexion);
            requete1.Parameters.AddWithValue("@nom", ssrub.Nom);
            requete1.Parameters.AddWithValue("@rubriqueid", ssrub.SousRubriqueId);
            requete1.ExecuteNonQuery();
            MaConnexion.Close();
        }

        public void Update(SousRubrique ssrub)
        {
            MaConnexion.Open();
            SqlCommand requete3 = new SqlCommand("update sous_rubrique set ss_rubrique_nom=@nom, rubrique_id=@rubriqueid from sous_rubrique where ss_rubrique_id = @id", MaConnexion);
            requete3.Parameters.AddWithValue("@id", ssrub.Id);
            requete3.Parameters.AddWithValue("@nom", ssrub.Nom);
            requete3.Parameters.AddWithValue("@nom", ssrub.SousRubriqueId);
            requete3.ExecuteNonQuery();
            MaConnexion.Close();

        }

        public SousRubrique Find(int id)
        {
            MaConnexion.Open();
            SqlCommand requete5 = new SqlCommand("Select * from sous_rubrique where ss_rubrique_id=@id", MaConnexion);
            requete5.Parameters.AddWithValue("@id", id);
            SqlDataReader resultat = requete5.ExecuteReader();
            resultat.Read();
            SousRubrique Nouveaussrubrique = new SousRubrique();
            Nouveaussrubrique.Id = Convert.ToInt32(resultat["ss_rubrique_id"].ToString());
            Nouveaussrubrique.Nom = resultat["ss_rubrique_nom"].ToString();
            Nouveaussrubrique.SousRubriqueId = Convert.ToInt32(resultat["rubrique_id"].ToString());
            resultat.Close();
            MaConnexion.Close();
            return Nouveaussrubrique;
        }
        public List<SousRubrique> List()
        {
            MaConnexion.Open();
            List<SousRubrique> resultat = new List<SousRubrique>();
            SqlCommand requete = new SqlCommand("select * from sous_rubrique", MaConnexion);

            SqlDataReader lecture = requete.ExecuteReader();
            while (lecture.Read())
            {
                SousRubrique sr = new SousRubrique();
                sr.Id = Convert.ToInt32(lecture["ss_rubrique_id"]);
                sr.Nom = Convert.ToString(lecture["ss_rubrique_nom"]);
                sr.SousRubriqueId = Convert.ToInt32(Convert.ToString(lecture["rubrique_id"]));
                resultat.Add(sr);
            }
            lecture.Close();
            MaConnexion.Close();
            return resultat;
        }
        //public double TrouverCATotalsous_rubrique()
        //{
        //    double CATotalrub = 0;
        //    MaConnexion.Open();
        //    SqlCommand requete6 = new SqlCommand("select sum(lignecom_qte*prix_fixe) As 'CAHTTotal' from ligne_de_commande", MaConnexion);
        //    SqlDataReader resultat = requete6.ExecuteReader();
        //    resultat.Read();
        //    CATotalrub = Convert.ToDouble(resultat["CAHTTotal"].ToString());
        //    resultat.Close();
        //    MaConnexion.Close();
        //    return CATotalrub;
        //}
        //public double TrouverCAsous_rubrique(int id)
        //{
        //    double CArub = 0;
        //    MaConnexion.Open();
        //    SqlCommand requete7 = new SqlCommand("select sous_rubrique.sous_rubrique_id, sum(lignecom_qte*prix_fixe) as 'total' from ligne_de_commande JOIN	PRODUIT ON	ligne_de_commande.produit_id = produit.produit_id JOIN	sous_rubrique	ON	produit.sous_rubrique_id=sous_rubrique.sous_rubrique_id where sous_rubrique.sous_rubrique_id=@id group by sous_rubrique.sous_rubrique_id", MaConnexion);
        //    requete7.Parameters.AddWithValue("@id", id);
        //    SqlDataReader resultat = requete7.ExecuteReader();
        //    if (resultat.Read())
        //    {
        //        CArub = Convert.ToDouble(resultat["total"].ToString());
        //    }
        //    resultat.Close();
        //    MaConnexion.Close();
        //    return CArub;
        //}
        //public double ListCAsous_rubrique(int id)
        //{
        //    double CArub = 0;
        //    MaConnexion.Open();
        //    SqlCommand requete7 = new SqlCommand("select sous_rubrique.sous_rubrique_id, sum(lignecom_qte*prix_fixe) as 'total' from ligne_de_commande JOIN	PRODUIT ON	ligne_de_commande.produit_id = produit.produit_id JOIN	sous_rubrique	ON	produit.sous_rubrique_id=sous_rubrique.sous_rubrique_id where sous_rubrique.sous_rubrique_id=@id group by sous_rubrique.sous_rubrique_id", MaConnexion);
        //    requete7.Parameters.AddWithValue("@id", id);
        //    SqlDataReader resultat = requete7.ExecuteReader();
        //    if (resultat.Read())
        //    {
        //        CArub = Convert.ToDouble(resultat["total"].ToString());
        //    }
        //    resultat.Close();
        //    MaConnexion.Close();
        //    return CArub;


        //}


    }
}
}