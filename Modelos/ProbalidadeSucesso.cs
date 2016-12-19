using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class ProbalidadeSucesso
    {
        [DataMember]
        public string Matricula { get; set; }
        [DataMember]
        public int NumeroReprovacoes { get; set; }

        [DataMember]
        public double Sucesso { get; set; }

        [DataMember] 
        public double InSucesso { get; set; }
    }
}