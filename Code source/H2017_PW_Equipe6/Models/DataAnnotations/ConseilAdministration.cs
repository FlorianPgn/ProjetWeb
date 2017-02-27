using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace H2017_PW_Equipe6.Models
{
    [MetadataType(typeof(ConseilAdministrationMetaData))]
    public partial class ConseilAdministration
    {
        private class ConseilAdministrationMetaData
        {
            [DisplayName("Nom")]
            public string nomCA { get; set; }

            [DisplayName("Prénom")]
            public string prenomCA { get; set; }

            [DisplayName("Son rôle détailé")]

            public string descriptionCA { get; set; }

            [DisplayName("Rôle CA")]
            public string idROLECA { get; set; }
        }
    }
}