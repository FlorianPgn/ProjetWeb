using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace H2017_PW_Equipe6.Models
{
    [MetadataType(typeof(ClubMetaData))]
    public partial class Club
    {
        private class ClubMetaData 
        {
            [DisplayName("Nom")]
            public string nom { get; set; }
            [DisplayName("Adresse")]
            public string adresse { get; set; }
            [DisplayName("Ville")]

            public string ville { get; set; }
            [DisplayName("Province")]

            public string province { get; set; }
            [DisplayName("Code postal")]

            public string codePostal { get; set; }
            [DisplayName("Numero de téléphone")]

            public string numTelephone { get; set; }
            [DisplayName("Courriel")]

            public string courriel { get; set; }
            [DisplayName("Description")]

            public string description { get; set; }
        }
    }
}