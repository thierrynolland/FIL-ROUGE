using System;
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
            SqlCommand requete1 = new SqlCommand("insert into sous_rubrique (ss_rubrique_nom,rubrique_id) values (@nom,@rubriqueid)", MaConnexion);
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
            requete3.Parameters.AddWithValue("@rubriqueid", ssrub.SousRubriqueId);
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
      

        public List<SousRubrique> List(int id)
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

        public List<SousRubrique> ListSSparRub(int id) //pour liste reduite de sous rubriqued par rubrique
        {
            MaConnexion.Open();
            List<SousRubrique> resultat = new List<SousRubrique>();
            SqlCommand requete = new SqlCommand("select * from sous_rubrique where rubrique_id=@id", MaConnexion);
            requete.Parameters.AddWithValue("@id", id);
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

    }
}

