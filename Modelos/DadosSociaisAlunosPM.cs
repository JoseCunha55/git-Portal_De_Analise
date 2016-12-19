using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PortalEducase.Web.Models
{
    [DataContract]
    public class DadosSociaisAlunosPM
    {
        [DataMember]
        public String Sigla_Curso { get; set; }
        [DataMember]
        public String Curso { get; set; }
        [DataMember]
        public short Ano { get; set; }
        [DataMember]
        public byte Semestre { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public string Forma_Ingresso { get; set; }
        [DataMember]
        public string Renda { get; set; }
        [DataMember]
        public string Escola_Origem { get; set; }
        [DataMember]
        public string Etnia { get; set; }
        [DataMember]
        public string Situacao { get; set; }
    }
}
