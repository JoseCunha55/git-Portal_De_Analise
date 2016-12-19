using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class ProbabilidadeSucessoEscola
    {
        [DataMember]
        public string Matricula { get; set; }
        [DataMember]
        public string Tema { get; set; }
        [DataMember]
        public int Reprovacao { get; set; }

        [DataMember]
        public double Sucesso { get; set; }
        [DataMember]
        public double InSucesso { get; set; }
    }
}