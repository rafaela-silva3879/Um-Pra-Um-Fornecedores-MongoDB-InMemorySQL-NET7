using Fornecedores.Domain.Models;
using Fornecedores.Infra.Data.MongoDB.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Infra.Data.MongoDB.Contexts
{
    public class MongoDbContext
    {
        private readonly IOptions<MongoDbSettings>? _mongoDbSettings;
        private IMongoDatabase _mongoDatabase;
        public MongoDbContext(IOptions<MongoDbSettings>? mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings;
            
            #region Conexão com o banco de dados
            var client = MongoClientSettings.FromUrl
            (new MongoUrl(_mongoDbSettings.Value.Host));
            if (_mongoDbSettings.Value.isSSL)
                client.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security
                .Authentication.SslProtocols.Tls12
                };
            _mongoDatabase = new MongoClient(client).GetDatabase
            (_mongoDbSettings.Value.Name);
            #endregion
        }

        #region Mapear as collections do banco de dados
        public IMongoCollection<Endereco> Enderecos
        => _mongoDatabase.GetCollection<Endereco>("enderecos");

        public IMongoCollection<Fornecedor> Fornecedores
        => _mongoDatabase.GetCollection<Fornecedor>("fornecedores");
        #endregion
    }
}
