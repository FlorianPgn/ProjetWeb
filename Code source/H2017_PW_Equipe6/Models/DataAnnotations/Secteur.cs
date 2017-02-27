using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace H2017_PW_Equipe6.Models
{
    [MetadataType(typeof(SecteurMetaData))]
    public partial class Secteur
    {
        private class SecteurMetaData
        {
            [DisplayName("Secteur")]
            public string nomSECTEUR { get; set; }
            [DisplayName("Description")]
            public string descriptionSECTEUR { get; set; }
        }
    }
}