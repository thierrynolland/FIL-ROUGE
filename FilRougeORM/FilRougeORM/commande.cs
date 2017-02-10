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
    
    public partial class commande
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public commande()
        {
            this.bon_livraison = new HashSet<bon_livraison>();
            this.ligne_de_commande = new HashSet<ligne_de_commande>();
        }
    
        public int commande_id { get; set; }
        public Nullable<decimal> commande_reduc { get; set; }
        public string commande_etat { get; set; }
        public Nullable<System.DateTime> commande_reglt { get; set; }
        public Nullable<System.DateTime> commande_date { get; set; }
        public Nullable<bool> commande_paye { get; set; }
        public string livraison_adr { get; set; }
        public string livraison_ville { get; set; }
        public string livraison_cp { get; set; }
        public int client_id { get; set; }
        public int facture_id { get; set; }
        public System.DateTime facture_date { get; set; }
        public Nullable<decimal> facture_montant { get; set; }
        public string facture_adre { get; set; }
        public string facture_ville { get; set; }
        public string facture_cp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bon_livraison> bon_livraison { get; set; }
        public virtual client client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ligne_de_commande> ligne_de_commande { get; set; }
    }
}
