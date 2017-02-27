using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace H2017_PW_Equipe6.Models
{
    [MetadataType(typeof(CompetitionMetaData))]
    public partial class Competition
    {
        private class CompetitionMetaData
        {
            [DisplayName("Nom")]
            public string nomCOMP { get; set; }

            [DisplayName("Date de début")]
            public System.DateTime dateDebutCOMP { get; set; }

            [DisplayName("Date de fin")]
            public System.DateTime dateFinCOMP { get; set; }

            [DisplayName("Adresse")]
            public string adresseCOMP { get; set; }

            [DisplayName("Description")]
            public string descriptionCOMP { get; set; }

            [DisplayName("Url du fichier des résultats")]
            public string urlFichierResultatsCOMP { get; set; }
        }
    }
}