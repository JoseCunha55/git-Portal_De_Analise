using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_De_Analise.Web.Models
{
    interface IPesquisas<TEntity> where TEntity : class 
    {
        // IQueryable de TEntity é o retorno no método Get, o qual será 
        // aplicado um filtro dinâmico no predicate 
        // p => p.Preco > 40 
        // c= > c.NomeCliente.Contains("a")
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate );
    }
}
