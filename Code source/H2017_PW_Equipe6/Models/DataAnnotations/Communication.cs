using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace H2017_PW_Equipe6.Models
{
    [MetadataType(typeof(CommunicationMetaData))]
    public partial class Communication
    {
        private class CommunicationMetaData
        {
            [Required, DisplayName("Titre")]
            public string titreCOM { get; set; }

            [Required, DisplayName("Contenu")]
            public string contenuCOM { get; set; }

            [DisplayName("Fichiers")]
            public virtual ICollection<FichierCommunication> FichierCommunications { get; set; }
        }
    }
}