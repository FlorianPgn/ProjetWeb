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
    
    public partial class Offre
    {
        public int idOFF { get; set; }
        public System.DateTime dateOFF { get; set; }
        public string titreOFF { get; set; }
        public string descriptionOFF { get; set; }
        public string profilOFF { get; set; }
        public bool estActif { get; set; }
        public int idClub { get; set; }
    }
}