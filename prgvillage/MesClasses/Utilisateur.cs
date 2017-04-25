using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class Utilisateur
    {
        public string Id { get; set; }
        public string MotDePasse { get; set; }
        public string Email { get; set; }
        public DateTime DateInscription { get; set; }
        public bool Confirm { get; set; }
        public string Type { get; set; }
        public int Idperso { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }




    }
}
