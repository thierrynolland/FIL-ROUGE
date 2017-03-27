using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class ClientDAO
    {
        SqlConnection MaConnexion;
        public ClientDAO(string chainedeconnection)
        {
            MaConnexion = new SqlConnection(chainedeconnection);
        }

        //ATTENTION TRAVAIL EN COURS MAIS PAS TESTE
        public void Insert(Client cli)
        {
            MaConnexion.Open();
            SqlCommand requete1 = new SqlCommand("insert into Client (client_categorie,client_nom,client_prenom,client_reduc,client_adresse,client_cp,client_ville,commercial_id) values (@categorie,@nom,@prenom,@reduction,@adresse,@ville,@cp,@commercial)", MaConnexion);
            requete1.Parameters.AddWithValue("@categorie", cli.Categorie);
            requete1.Parameters.AddWithValue("@nom", cli.Nom);
            requete1.Parameters.AddWithValue("@prenom", cli.Prenom);
            requete1.Parameters.AddWithValue("@reduction", cli.Reduction);
            requete1.Parameters.AddWithValue("@adresse", cli.Adresse);
            requete1.Parameters.AddWithValue("@cp", cli.CP);
            requete1.Parameters.AddWithValue("@ville", cli.Ville);
            requete1.Parameters.AddWithValue("@commercial", cli.CommercialId);
            requete1.ExecuteNonQuery();
            MaConnexion.Close();
        }
        //ATTENTION TRAVAIL EN COURS MAIS PAS TESTE
        public void Update(Client cli)
        {
            MaConnexion.Open();
            SqlCommand requete1 = new SqlCommand("update client set client_categorie=@categorie,client_nom=@nom,client_prenom=@prenom,client_reduc=@reduction,client_adresse=@adresse,client_ville=@ville,client_cp=@cp,commercial_id=@commercial from client where client_id = @id", MaConnexion);
            requete1.Parameters.AddWithValue("@id", cli.Id);
            requete1.Parameters.AddWithValue("@categorie", cli.Categorie);
            requete1.Parameters.AddWithValue("@nom", cli.Nom);
            requete1.Parameters.AddWithValue("@prenom", cli.Prenom);
            requete1.Parameters.AddWithValue("@reduction", cli.Reduction);
            requete1.Parameters.AddWithValue("@adresse", cli.Adresse);
            requete1.Parameters.AddWithValue("@cp", cli.CP);
            requete1.Parameters.AddWithValue("@ville", cli.Ville);
            requete1.Parameters.AddWithValue("@commercial", cli.CommercialId);
            requete1.ExecuteNonQuery();
            MaConnexion.Close();

        }
        //ATTENTION TRAVAIL EN COURS MAIS PAS TESTE
        public void Delete(Client cli)
        {
            MaConnexion.Open();
            SqlCommand requete4 = new SqlCommand("delete from client where client_id = @id", MaConnexion);
            requete4.Parameters.AddWithValue("@id", cli.Id);
            requete4.ExecuteNonQuery();
            MaConnexion.Close();
        }
        //ATTENTION TRAVAIL EN COURS MAIS PAS TESTE
        public Client Find(int id)
        {
            MaConnexion.Open();
            SqlCommand requete5 = new SqlCommand("Select * from client where client_id=@id", MaConnexion);
            requete5.Parameters.AddWithValue("@id", id);
            SqlDataReader resultat = requete5.ExecuteReader();
            resultat.Read();
            Client NouveauClient = new Client();
            NouveauClient.Id = Convert.ToInt32(resultat["client_id"]);
            NouveauClient.Categorie = Convert.ToInt32(resultat["client_categorie"]);
            NouveauClient.Nom = resultat["client_nom"].ToString();
            NouveauClient.Prenom = resultat["client_prenom"].ToString();
            NouveauClient.Ville = resultat["client_ville"].ToString();
            NouveauClient.CP = resultat["client_cp"].ToString();
            NouveauClient.Adresse = resultat["client_adresse"].ToString();
            NouveauClient.Reduction = Convert.ToDecimal(resultat["client_reduc"]);
            NouveauClient.CommercialId = Convert.ToInt32(resultat["commercial_id"]);
            resultat.Close();
            MaConnexion.Close();

            return NouveauClient;
        }
        //ATTENTION TRAVAIL EN COURS MAIS PAS TESTE
        public List<Client> List()
        {
            MaConnexion.Open();
            List<Client> resultat = new List<Client>();
            SqlCommand requete = new SqlCommand("select * from client", MaConnexion);
            SqlDataReader lecture = requete.ExecuteReader();
            while (lecture.Read())
            {
                Client c = new Client();
                c.Id = Convert.ToInt32(lecture["client_id"]);
                c.Categorie = Convert.ToInt32(lecture["client_categorie"]);
                c.Nom = lecture["client_nom"].ToString();
                c.Prenom = lecture["client_prenom"].ToString();
                c.Ville = lecture["client_ville"].ToString();
                c.CP = lecture["client_cp"].ToString();
                c.Adresse = lecture["client_adresse"].ToString();
                c.Reduction = Convert.ToDecimal(lecture["client_reduc"]);
                c.CommercialId = Convert.ToInt32(lecture["commercial_id"]);
                resultat.Add(c);
            }
            lecture.Close();
            MaConnexion.Close();
            return resultat;
        }
        
    }
}
