using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class TvaDAO
    {
        SqlConnection MaConnexion;
        public TvaDAO(string chainedeconnection)
        {
            MaConnexion = new SqlConnection(chainedeconnection);
        }
        public List<Tva> List()
        {
            MaConnexion.Open();
            List<Tva> resultat = new List<Tva>();
            SqlCommand requete = new SqlCommand("select * from tva", MaConnexion);

            SqlDataReader lecture = requete.ExecuteReader();
            while (lecture.Read())
            {
                Tva t = new Tva();
                t.Id = Convert.ToInt32(lecture["tva_id"]);
                t.Nom = lecture["tva_nom"].ToString();
                t.Taux = Convert.ToDouble(lecture["tva_taux"]);
                resultat.Add(t);
            }
            lecture.Close();
            MaConnexion.Close();
            return resultat;
        }

        public Tva Find(int id)
        {
            MaConnexion.Open();
            SqlCommand requete = new SqlCommand("Select * from tva where tva_id=@id", MaConnexion);
            requete.Parameters.AddWithValue("@id", id);
            SqlDataReader lecture = requete.ExecuteReader();
            lecture.Read();
            Tva t = new Tva();
            t.Id = Convert.ToInt32(lecture["tva_id"]);
            t.Nom = lecture["tva_nom"].ToString();
            t.Taux = Convert.ToDouble(lecture["tva_taux"]);
            lecture.Close();
            MaConnexion.Close();
            return t;
        }
    }
}
