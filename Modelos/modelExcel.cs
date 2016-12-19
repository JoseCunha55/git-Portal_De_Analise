using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class modelExcel
    {
        [DataMember]
        public string Caminho { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public System.Security.SecureString Senha { get; set; }
        [DataMember]
        public string Dominio { get; set; } 
    }
}