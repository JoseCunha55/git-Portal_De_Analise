using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Portal_De_Analise.Web.Models
{
    //[DataContract]
    //public class PesquisaGenerica<TEntity> : IDisposable, IPesquisas<TEntity> where TEntity : class
    //{
        //TEntity é uma classe (where)
        //IQueryable<TEntity> IPesquisas<TEntity>.Get(Func<TEntity, bool> predicate)
        //{
        //    //Substituir pelo banco de dados
        //    //NORTHWNDEntities ctx = new NORTHWNDEntities();

        //    //TEntity = é uma classe, ex Produtos, Clientes 
        //    // predicate = é a expressão de filtro 
        //    // p => p.Preco > 10 
        //    // AsQueryable = converte para uma lista consultável 
        //    // .Set<> referencia a entidade dinamicamente
        //    //return ctx.Set<TEntity>().Where(predicate).AsQueryable();
        //}

        //public void Dispose()
        //{
        //    //ctx.Dispose();
        //}
    //}
}