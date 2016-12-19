using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class ReprovadosPorCampus
    {
        [DataMember]
        public string Campus { get; set; }
        [DataMember]
        public string Curso { get; set; }
        [DataMember]
        public string Situacao { get; set; }
        [DataMember]
        public int Ano { get; set; }
        [DataMember]
        public int Semestre { get; set; }
        [DataMember]
        public int Total { get; set; }
    }
}