//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FilRougeORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class ligne_de_commande
    {
        public int lignecom_id { get; set; }
        public int lignecom_qte { get; set; }
        public decimal prix_fixe { get; set; }
        public int commande_id { get; set; }
        public int produit_id { get; set; }
    
        public virtual commande commande { get; set; }
        public virtual produit produit { get; set; }
    }
}
