using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Domain.Models
{
    [BsonIgnoreExtraElements]
    [DataContract]
    [BsonNoId]
    public class Fornecedor
    {
        [DataMember]
        public Guid IdFornecedor { get; set; }


        //O mongoDB tem 3 ids default: Id, id e _id. Se colocar uma dessas 3,
        //não precisa mapear.
        //public Guid Id { get; set; }



        [DataMember]
        public string? Nome { get; set; }

        [DataMember]
        public string? CNPJ { get; set; }

        [DataMember]
        public string? Telefone { get; set; }

        [DataMember]
        public Guid? IdEndereco { get; set; }

        [DataMember]
        public Endereco? Endereco { get; set; }
    }
}
