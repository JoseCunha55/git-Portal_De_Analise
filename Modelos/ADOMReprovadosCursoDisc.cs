using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class ADOMReprovadosCursoDisc
    {
        [DataMember]
        public string Curso {get;set;}
        [DataMember]
        public string Disciplina { get; set; }
        [DataMember]
        public int Aprovados { get; set; }
        [DataMember]
        public int Reprovados { get; set; }
    }
}