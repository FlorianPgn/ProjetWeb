using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2017_PW_Equipe6.Models
{
    public partial class NouvelleCommunication
    {
        public Communication communication { get; set; }

        public IEnumerable<int> SelectedGroupId { get; set; }

        public IEnumerable<int> SelectedNiveauId { get; set; }

        public IEnumerable<int> SelectedSecteurId { get; set; }
    }
}