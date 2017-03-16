using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public class LigneDeCommande
    {
        public int Id { get; set; }
        public int ProduitId { get; set; }
        public int CommandeId { get; set; }
        public decimal PrixFixe { get; set; }
        public int Qte { get; set; }
    }
}
