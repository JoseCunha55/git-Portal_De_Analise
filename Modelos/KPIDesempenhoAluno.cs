using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class KPIDesempenhoAluno
    {
        [DataMember]
        public int BoletimID { get; set; }

        [DataMember]
        public string Matricula { get; set; }

        [DataMember]
        public string SiglaCurso { get; set; }

        [DataMember]
        public string Campus { get; set; }

        [DataMember]
        public string Turma { get; set; }

        [DataMember]
        public string AnoLetivo { get; set; }

        [DataMember]
        public int PeriodoLetivo { get; set; }

        [DataMember]
        public decimal Rendimento { get; set; }
    }
}