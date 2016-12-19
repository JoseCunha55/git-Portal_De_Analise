using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class ReprovadoPorCurso
    {
        [DataMember]
        public string Curso { get; set; }
        [DataMember]
        public string Situacao { get; set; }
        [DataMember]
        public int Ano { get; set; }
        [DataMember]
        public int Total { get; set; }
    }
}