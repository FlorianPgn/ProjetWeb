using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace H2017_PW_Equipe6.Models
{
    [MetadataType(typeof(REF_RoleCAMetaData))]
    public partial class REF_RoleCA
    {
        private class REF_RoleCAMetaData
        {
            [DisplayName("Son rôle")]
            public string descriptionROLECA { get; set; }
            [DisplayName("Rôle CA")]
            public string idROLECA { get; set; }
        }
    }
}