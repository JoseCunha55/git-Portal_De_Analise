using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class IndicadorCNATCurso
    {
        [DataMember]
        public string Indicadores { get; set; }

        [DataMember]
        public decimal ANO_2005 { get; set; }

        [DataMember]
        public decimal ANO_2006 { get; set; }

        [DataMember]
        public decimal ANO_2007 { get; set; }
        [DataMember]
        public decimal ANO_2008 { get; set; }
        [DataMember]
        public decimal ANO_2009 { get; set; }
        [DataMember]
        public decimal ANO_2010 { get; set; }
        [DataMember]
        public decimal ANO_2011 { get; set; }
        [DataMember]
        public decimal ANO_2012 { get; set; }
        [DataMember]
        public decimal ANO_2013 { get; set; }
        [DataMember]
        public decimal ANO_2014 { get; set; }
        [DataMember]
        public decimal ANO_2015 { get; set; }

        [DataMember]
        public decimal Média { get; set; }
        [DataMember]
        public string Campus { get; set; }

        [DataMember]
        public string Curso { get; set; }
    }
}