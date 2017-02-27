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
    
    public partial class Membre
    {
        public Membre()
        {
            this.Paiements = new HashSet<Paiement>();
            this.Representants = new HashSet<Representant>();
            this.Groupes = new HashSet<Groupe>();
        }
    
        public int idMEMBRE { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public bool sexe { get; set; }
        public System.DateTime dateNaissance { get; set; }
        public int numAssuranceMaladie { get; set; }
        public string adresse { get; set; }
        public string ville { get; set; }
        public string codePostal { get; set; }
        public string telephone { get; set; }
        public string courriel { get; set; }
        public string allergie { get; set; }
        public string codeReinscription { get; set; }
        public System.DateTime dateCourrielReinscription { get; set; }
        public bool paiementEffectuer { get; set; }
        public Nullable<int> niveauSuivant { get; set; }
        public int idClub { get; set; }
    
        public virtual ICollection<Paiement> Paiements { get; set; }
        public virtual ICollection<Representant> Representants { get; set; }
        public virtual ICollection<Groupe> Groupes { get; set; }
    }
}
