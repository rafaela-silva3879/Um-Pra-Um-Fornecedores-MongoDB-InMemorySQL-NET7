using Fornecedores.Domain.Interfaces.Cache;
using Fornecedores.Domain.Models;
using Fornecedores.Infra.Data.MongoDB.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Infra.Data.MongoDB.Cache
{
    public class EnderecoCache : IEnderecoCache
    {
        private readonly MongoDbContext? _mongoDbContext;
        public EnderecoCache(MongoDbContext? mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }
        public void Add(Endereco entity)
        {
            _mongoDbContext.Enderecos.InsertOne(entity);
        }
        public void Update(Endereco entity)
        {
            var filter = Builders<Endereco>.Filter
            .Eq(c => c.IdEndereco, entity.IdEndereco);
            _mongoDbContext.Enderecos.ReplaceOne(filter, entity);
        }
        public void Delete(Endereco entity)
        {
            var filter = Builders<Endereco>.Filter
            .Eq(c => c.IdEndereco, entity.IdEndereco);
            _mongoDbContext.Enderecos.DeleteOne(filter);
        }
        public List<Endereco> GetAll()
        {
            var filter = Builders<Endereco>.Filter.Where(c => true);
            return _mongoDbContext.Enderecos.Find(filter).ToList();
        }
       /* public Endereco GetById(Guid IdEndereco)
        {
            var filter = Builders<Endereco>.Filter.Eq(c => c.IdEndereco, IdEndereco);
            return _mongoDbContext.Enderecos.Find(filter).FirstOrDefault();
        }*/

        public Endereco GetById(Guid IdEndereco)
        {

            var client = new MongoClient();
            var database = client.GetDatabase("dbFornecedor");
            var collection = database.GetCollection<Endereco>("enderecos");

            var result = collection.Find(e => e.IdEndereco == IdEndereco).FirstOrDefault();

            return result;

        }
    }
}