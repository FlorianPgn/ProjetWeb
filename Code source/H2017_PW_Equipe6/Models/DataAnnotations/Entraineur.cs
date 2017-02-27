using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace H2017_PW_Equipe6.Models
{
    [MetadataType(typeof(EntraineurMetaData))]
    public partial class Entraineur
    {
        private class EntraineurMetaData
        {
            [Required, DisplayName("Description")]
            public string descriptionENT { get; set; }

            [Required, DisplayName("Actif ?")]
            public string estActifENT { get; set; }

            [Required, DisplayName("Photo")]
            public string photoENT { get; set; }
        }
    }
}