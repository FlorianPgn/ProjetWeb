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
    
    public partial class Photo
    {
        public int idPHOTO { get; set; }
        public string pathFichier { get; set; }
        public int idCOMPETITION { get; set; }
    
        public virtual Competition Competition { get; set; }
    }
}
