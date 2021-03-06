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
    
    public partial class Club
    {
        public Club()
        {
            this.Competitions = new HashSet<Competition>();
            this.PhotoClubs = new HashSet<PhotoClub>();
            this.Secteurs = new HashSet<Secteur>();
            this.REF_RoleCA = new HashSet<REF_RoleCA>();
        }
    
        public int id { get; set; }
        public string nom { get; set; }
        public string adresse { get; set; }
        public string ville { get; set; }
        public string province { get; set; }
        public string codePostal { get; set; }
        public string numTelephone { get; set; }
        public string courriel { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<PhotoClub> PhotoClubs { get; set; }
        public virtual ICollection<Secteur> Secteurs { get; set; }
        public virtual ICollection<REF_RoleCA> REF_RoleCA { get; set; }
    }
}
