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
    
    public partial class sous_rubrique
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sous_rubrique()
        {
            this.produit = new HashSet<produit>();
        }
    
        public int ss_rubrique_id { get; set; }
        public string ss_rubrique_nom { get; set; }
        public int rubrique_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<produit> produit { get; set; }
        public virtual rubrique rubrique { get; set; }
    }
}
