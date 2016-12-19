using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class ConsultaMDX
    {
        [DataMember]
        public string ConMDXID { get; set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public string MDX { get; set; }
    }
}