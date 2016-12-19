using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal_De_Analise.Web.Models
{
    public class ReprovadosPorDiscCurso
    {
        public string Curso { get; set; }
        public string Disciplina { get; set; }
        public int Ano { get; set; }
        public int Semestre { get; set; }
        public string Situacao { get; set; }
        public int Total { get; set; }
    }
}