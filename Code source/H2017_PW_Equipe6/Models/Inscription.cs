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
    
    public partial class Inscription
    {
        public int idINSCRIPTION { get; set; }
        public int idSESSION { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string sexe { get; set; }
        public System.DateTime dateNaissance { get; set; }
        public int numAssuranceMaladie { get; set; }
        public string adresse { get; set; }
        public string ville { get; set; }
        public string casierPostal { get; set; }
        public string telephone { get; set; }
        public string courriel { get; set; }
        public string allergie { get; set; }
        public string nomRepresentant1 { get; set; }
        public string prenomRepresentant1 { get; set; }
        public string roleRepresentant1 { get; set; }
        public string courrielRepresentant1 { get; set; }
        public string nomRepresentant2 { get; set; }
        public string prenomRepresentant2 { get; set; }
        public string roleRepresentant2 { get; set; }
        public string courrielRepresentant2 { get; set; }
        public System.DateTime dateCreation { get; set; }
        public string codeReinscription { get; set; }
        public bool meContacter { get; set; }
    
        public virtual Session Session { get; set; }
    }
}
