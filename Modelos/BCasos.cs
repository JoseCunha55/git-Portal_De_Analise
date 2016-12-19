using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class BCasos
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string MATRICULA { get; set; }
        [DataMember]
        public string NOME { get; set; }
        [DataMember]
        public string SEXO { get; set; }
        [DataMember]
        public string TELEFONE { get; set; }
        [DataMember]
        public string EMAIL { get; set; }
        [DataMember]
        public string CURSO { get; set; }
        [DataMember]
        public int PERIODO { get; set; }
        [DataMember]
        public DateTime DATA { get; set; }
        [DataMember]
        public string OBSERVACOES { get; set; }
        [DataMember]
        public string contexto { get; set; }
        [DataMember]
        public string atendidoPor { get; set; }
       
    }
}