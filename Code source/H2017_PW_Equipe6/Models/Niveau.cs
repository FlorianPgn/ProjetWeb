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
    
    public partial class Niveau
    {
        public Niveau()
        {
            this.NiveauSessions = new HashSet<NiveauSession>();
        }
    
        public int idNIVEAU { get; set; }
        public int TypeSECTEUR { get; set; }
        public string descriptionNIVEAU { get; set; }
        public int ordreAffichageNIVEAU { get; set; }
        public string nomNIVEAU { get; set; }
    
        public virtual Secteur Secteur { get; set; }
        public virtual ICollection<NiveauSession> NiveauSessions { get; set; }
    }
}
