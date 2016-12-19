using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class IndicarEnsino
    {
        [DataMember]
        public string Indicador { get; set; }
        [DataMember]
        public decimal Ano_2005 { get; set; }
        [DataMember]
        public decimal Ano_2006 { get; set; }
        [DataMember]
        public decimal Ano_2007 { get; set; }
        [DataMember]
        public decimal Ano_2008 { get; set; }
        [DataMember]
        public decimal Ano_2009 { get; set; }
        [DataMember]
        public decimal Ano_2010 { get; set; }
        [DataMember]
        public decimal Ano_2011 { get; set; }
        [DataMember]
        public decimal Ano_2012 { get; set; }
        [DataMember]
        public decimal Ano_2013 { get; set; }
        [DataMember]
        public decimal Ano_2014 { get; set; }
        [DataMember]
        public decimal Ano_2015 { get; set; }

        [DataMember]
        public decimal Media { get; set; }

        [DataMember]
        public string Campus { get; set; }
        [DataMember]
        public string SiglaCurso { get; set; }
    }
}