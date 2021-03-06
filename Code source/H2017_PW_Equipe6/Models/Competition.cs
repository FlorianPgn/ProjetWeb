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
    
    public partial class Competition
    {
        public Competition()
        {
            this.FichierComps = new HashSet<FichierComp>();
            this.Photos = new HashSet<Photo>();
        }
    
        public int idCOMP { get; set; }
        public string nomCOMP { get; set; }
        public System.DateTime dateDebutCOMP { get; set; }
        public System.DateTime dateFinCOMP { get; set; }
        public string adresseCOMP { get; set; }
        public string descriptionCOMP { get; set; }
        public string urlFichierResultatsCOMP { get; set; }
        public int idCLUB { get; set; }
    
        public virtual Club Club { get; set; }
        public virtual ICollection<FichierComp> FichierComps { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
