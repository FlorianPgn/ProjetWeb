//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace H2017_PW_Equipe6.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class REF_Jour
    {
        public REF_Jour()
        {
            this.HoraireGroupes = new HashSet<HoraireGroupe>();
        }
    
        public int idJOUR { get; set; }
        public string nomJOUR { get; set; }
    
        public virtual ICollection<HoraireGroupe> HoraireGroupes { get; set; }
    }
}