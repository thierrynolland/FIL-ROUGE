using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class Commande
    {
        public int Id { get; set; }
        public decimal Reduction { get; set; }
        public string Etat { get; set; }
        public DateTime Reglement { get; set; }
        public DateTime Date { get; set; }
        public bool Paiement { get; set; }
        public string AdresseLivraison { get; set;}
        public string CPLivraison { get; set; }
        public string VilleLivraison { get; set; }
        public int ClientId { get; set; }
        public int FactureId { get; set; }
        public DateTime FactureDate { get; set; }
        public decimal FactureMontant { get; set; }
        public string AdresseFacture { get; set; }
        public string CPFacture { get; set; }
        public string VilleFacture { get; set; }

    }
}
