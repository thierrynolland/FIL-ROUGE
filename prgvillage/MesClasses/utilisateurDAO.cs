using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class UtilisateurDAO
    {
        SqlConnection MaConnexion;
        public UtilisateurDAO(string chainedeconnection)
        {
            MaConnexion = new SqlConnection(chainedeconnection);
        }



        public Utilisateur Find(string id)
        {
            MaConnexion.Open();
            SqlCommand requete = new SqlCommand("select * from utilisateur where util_identifiant=@id", MaConnexion);
            requete.Parameters.AddWithValue("@id", id);
            SqlDataReader resultat = requete.ExecuteReader();
            resultat.Read();
            Utilisateur NouvelUtilisateur = new Utilisateur();
            NouvelUtilisateur.Id =resultat["util_Identifiant"].ToString();
            NouvelUtilisateur.MotDePasse = resultat["util_MotPasse"].ToString();
            NouvelUtilisateur.Email = resultat["util_Email"].ToString();
            NouvelUtilisateur.DateInscription = Convert.ToDateTime(resultat["util_DateInscrip"]);
            NouvelUtilisateur.Confirm = Convert.ToBoolean(resultat["util_Confirm"]);
            NouvelUtilisateur.Type = resultat["util_Type"].ToString();
            NouvelUtilisateur.Idperso = Convert.ToInt32(resultat["util_IdPerso"]);
            NouvelUtilisateur.Nom = resultat["util_Nom"].ToString();
            NouvelUtilisateur.Prenom = resultat["util_Prenom"].ToString();

            resultat.Close();
            MaConnexion.Close();

            return NouvelUtilisateur;
        }


    }
}
