using Fornecedores.Domain.Interfaces.Cache;
using Fornecedores.Domain.Models;
using Fornecedores.Infra.Data.MongoDB.Contexts;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Infra.Data.MongoDB.Cache
{
    public class FornecedorCache : IFornecedorCache
    {
        private readonly MongoDbContext? _mongoDbContext;
        public FornecedorCache(MongoDbContext? mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }
        public void Add(Fornecedor entity)
        {
            _mongoDbContext.Fornecedores.InsertOne(entity);
        }
        public void Update(Fornecedor entity)
        {
            var filter = Builders<Fornecedor>.Filter.Eq(c => c.IdFornecedor, entity.IdFornecedor);
            _mongoDbContext.Fornecedores.ReplaceOne(filter, entity);
        }
        public void Delete(Fornecedor entity)
        {
            var filter = Builders<Fornecedor>.Filter.Eq(c => c.IdFornecedor, entity.IdFornecedor);
            _mongoDbContext.Fornecedores.DeleteOne(filter);
        }
        public List<Fornecedor> GetAll()
        {
            //foenecedores
            var filter = Builders<Fornecedor>.Filter.Empty;
            var retorno = _mongoDbContext.Fornecedores.Find(filter).ToList();


            //enderecos
            /*
            var client = new MongoClient();
            var database = client.GetDatabase("dbFornecedores"); 
            var collectionEnderecos = database.GetCollection<Endereco>("enderecos").AsQueryable().ToList();
            */
            // var filterEnd = Builders<Endereco>.Filter.Empty;
            //var retornoEnd = _mongoDbContext.Enderecos.Find(filterEnd).ToList();


            var lista = new List<Fornecedor>();

            foreach (var item in retorno)
            {
                var f = new Fornecedor();

                f = item;
                f.Endereco = new Endereco();
                var filterEnd = Builders<Endereco>.Filter.Eq(e => e.IdEndereco, f.IdEndereco);
                f.Endereco = new Endereco();
                f.Endereco = _mongoDbContext.Enderecos.Find(filterEnd).FirstOrDefault();

                lista.Add(f);
            }
            return lista;
        }
        public Fornecedor GetById(Guid IdFornecedor)
        {

            var filter = Builders<Fornecedor>.Filter.Eq(c => c.IdFornecedor, IdFornecedor);
            var results = _mongoDbContext.Fornecedores.Find(filter).FirstOrDefault();



            /*
               var client = new MongoClient();
               var database = client.GetDatabase("dbFornecedores");

               var collection = database.GetCollection<Fornecedor>("fornecedores");
               var results = collection.Find(f => f.IdFornecedor == IdFornecedor).FirstOrDefault();

            //enderecos
            var collectionEnderecos = database.GetCollection<Endereco>("enderecos").AsQueryable().ToList();
            results.Endereco = new Endereco();
            results.Endereco = collectionEnderecos.Where(e => e.IdEndereco == results.IdEndereco).FirstOrDefault();
           
             */
            //enderecos

            var filterEnd = Builders<Endereco>.Filter.Eq(e => e.IdEndereco, results.IdEndereco);
            results.Endereco = new Endereco();
            results.Endereco = _mongoDbContext.Enderecos.Find(filterEnd).FirstOrDefault();



            return results;

        }
    }
}