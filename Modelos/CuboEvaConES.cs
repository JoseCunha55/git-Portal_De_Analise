using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Runtime.Serialization;
namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class CuboEvaConES
    {
        [DataMember]
        public string Curso { get; set; }
        [DataMember]
        public string Campus { get; set; }
        [DataMember]
        public decimal Concluidos { get; set; }
        [DataMember]
        public decimal Evadidos { get; set; }
        [DataMember]
        public decimal PerConclusao { get; set; }
        [DataMember]
        public decimal PerEvadidos { get; set; }
        [DataMember]
        public int TotalEvaCon { get; set; }
    }
}