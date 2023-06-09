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
    public class Endereco
    {
        /// <summary>
        /// DataMember: Para o MongoDB
        /// </summary>
        [DataMember]
        public Guid? IdEndereco { get; set; }

        [DataMember]
        public string? Logradouro { get; set; }

        [DataMember]
        public string? Complemento { get; set; }

        [DataMember]
        public string? Numero { get; set; }

        [DataMember]
        public string? Bairro { get; set; }

        [DataMember]
        public string? Cidade { get; set; }

        [DataMember]
        public string? Estado { get; set; }

        [DataMember]
        public string? Cep { get; set; }

        [DataMember]
        public Fornecedor? Fornecedor { get; set; }

    }
}
