using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class ObjAMO
    {
        [DataMember]
        public string ColunaA { get; set; }
        [DataMember]
        public string ColunaB { get; set; }
        [DataMember]
        public int ColunaC { get; set; }
        [DataMember]
        public int ColunaD { get; set; }
        [DataMember]
        public decimal ColunaPAp { get; set; }

        [DataMember]
        public decimal ColunaPRp { get; set; }
    }
}