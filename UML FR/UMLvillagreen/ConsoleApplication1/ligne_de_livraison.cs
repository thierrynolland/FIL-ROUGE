//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class ligne_de_livraison
    {
        public int ligneliv_id { get; set; }
        public int ligneliv_qte { get; set; }
        public int livraison_id { get; set; }
        public int produit_id { get; set; }
    
        public virtual bon_livraison bon_livraison { get; set; }
        public virtual produit produit { get; set; }
    }
}
