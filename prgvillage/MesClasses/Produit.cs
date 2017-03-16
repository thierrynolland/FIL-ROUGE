using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class Produit
    {
        public int Id { get; set; }
        public string NomCourt { get; set; }
        public string NomLong { get; set; }
        public double PrixAchat { get; set; }
        public double PrixVenteHT { get; set; }
        public string Photo { get; set; }
        public bool Etat { get; set; }
        public bool Validite { get; set; }
        public int IDTVA { get; set; }
        public int IDFournisseur { get; set; }
        public int IDSousRubrique { get; set; }


    }
}
