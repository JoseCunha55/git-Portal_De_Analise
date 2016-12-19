using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class IndicadorLicenciaturas
    {
        [DataMember]
        public string Curso { get; set; }
        [DataMember]
        public int TotalEvadidos { get; set; }
        [DataMember]
        public int TotalConcluidos { get; set; }

        [DataMember]
        public int TotalAlunos { get; set; }

        [DataMember]
        public decimal TaxaEvasao { get; set; }

        [DataMember]
        public decimal TaxaConclusao { get; set; }
    }
}