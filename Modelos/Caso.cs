using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Runtime.Serialization;
namespace Portal_De_Analise.Web.Models
{
    [DataContract]
    public class Caso
    {
        [BsonElement ("_Id")]
        public ObjectId Id { set; get; }
        [BsonElement ("contexto")]
        public string Contexto { set; get; }
        [BsonElement("sexo")]
        public int Sexo { set; get; }
        [BsonElement("periodo")]
        public int Periodo { set; get; }
        [BsonElement("curso")]
        public string Curso { set; get; }
        [BsonElement("nome")]
        public string Nome { set; get; }
        [BsonElement("data")]
        public string Data { set; get; }
        [BsonElement("matricula")]
        public string Matricula { set; get; }
        [BsonElement("atendidopor")]
        public string AtendidoPor { set; get; }
        [BsonElement("classe")]
        public string Classe { set; get; }

    }
}