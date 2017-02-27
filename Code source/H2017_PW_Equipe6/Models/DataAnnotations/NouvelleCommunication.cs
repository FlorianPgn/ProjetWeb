using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace H2017_PW_Equipe6.Models
{
    [MetadataType(typeof(NouvelleCommunicationMetaData))]
    public partial class NouvelleCommunication
    {
        private class NouvelleCommunicationMetaData
        {
            [DisplayName("Communication")]
            public Communication communication { get; set; }

            [DisplayName("Groupes")]
            public ICollection<int> SelectedGroupId { get; set; }

            [DisplayName("Niveaux")]
            public IEnumerable<int> SelectedNiveauId { get; set; }

            [DisplayName("Secteurs")]
            public IEnumerable<int> SelectedSecteurId { get; set; }
        }
    }
}