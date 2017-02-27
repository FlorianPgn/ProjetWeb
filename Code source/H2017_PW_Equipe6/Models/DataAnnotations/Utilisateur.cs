using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace H2017_PW_Equipe6.Models
{
    [MetadataType(typeof(UtilisateurMetaData))]
    public partial class Utilisateur
    {
        private class UtilisateurMetaData
        {
            [DisplayName("Type d'utilisateur")]
            public int typeUTIL { get; set; }

            [DisplayName("Est un entraineur en chef")]
            public bool entrainerChefUTIL { get; set; }

            [DisplayName("Nom")]
            public string nomUTIL { get; set; }

            [DisplayName("Prénom")]
            public string prenomUTIL { get; set; }

            [DisplayName("Courriel")]
            public string courrielUTIL { get; set; }

            [DisplayName("Adresse")]
            public string adresseUTIL { get; set; }

            [DisplayName("Ville")]
            public string villeUTIL { get; set; }

            [DisplayName("Code postal")]
            public string codePostalUTIL { get; set; }

            [DisplayName("Téléphone")]
            public string telephoneUTIL { get; set; }
        }
    }
}