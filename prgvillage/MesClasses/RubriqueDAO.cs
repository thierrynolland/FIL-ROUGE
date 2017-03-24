using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class RubriqueDAO
    {
        SqlConnection MaConnexion;
        public RubriqueDAO(string chainedeconnection)
        {
            MaConnexion = new SqlConnection(chainedeconnection);
        }
        public void Insert(Rubrique rub)
        {
            MaConnexion.Open();
            SqlCommand requete1 = new SqlCommand("insert into rubrique (rubrique_nom) values (@nom)", MaConnexion);
            requete1.Parameters.AddWithValue("@nom", rub.Nom);
            requete1.ExecuteNonQuery();
            MaConnexion.Close();
        }

        public void Update(Rubrique rub)
        {
            MaConnexion.Open();
            SqlCommand requete3 = new SqlCommand("update rubrique set rubrique_nom=@nom from rubrique where rubrique_id = @id", MaConnexion);
            requete3.Parameters.AddWithValue("@id", rub.Id);
            requete3.Parameters.AddWithValue("@nom", rub.Nom);
            requete3.ExecuteNonQuery();
            MaConnexion.Close();

        }

        public Rubrique Find(int id)
        {
            MaConnexion.Open();
            SqlCommand requete5 = new SqlCommand("Select * from rubrique where rubrique_id=@id", MaConnexion);
            requete5.Parameters.AddWithValue("@id", id);
            SqlDataReader lecture = requete5.ExecuteReader();
            lecture.Read();
            Rubrique NouveauRubrique = new Rubrique();
            NouveauRubrique.Id = Convert.ToInt32(lecture["rubrique_id"].ToString());
            NouveauRubrique.Nom = lecture["rubrique_nom"].ToString();
            lecture.Close();
            MaConnexion.Close();
            return NouveauRubrique;
        }
        public List<Rubrique> List()
        {
            MaConnexion.Open();
            List<Rubrique> resultat = new List<Rubrique>();
            SqlCommand requete = new SqlCommand("select * from rubrique", MaConnexion);

            SqlDataReader lecture = requete.ExecuteReader();
            while (lecture.Read())
            {
                Rubrique r = new Rubrique();
                r.Id = Convert.ToInt32(lecture["rubrique_id"]);
                r.Nom = Convert.ToString(lecture["rubrique_nom"]);
                resultat.Add(r);
            }
            lecture.Close();
            MaConnexion.Close();
            return resultat;
        }
       

    }
}
