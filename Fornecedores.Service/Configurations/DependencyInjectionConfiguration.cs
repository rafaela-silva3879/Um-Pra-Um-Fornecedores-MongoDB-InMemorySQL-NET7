using Fornecedores.Application.Interfaces;
using Fornecedores.Application.Services;
using Fornecedores.Domain.Interfaces.Cache;
using Fornecedores.Domain.Interfaces.Repositories;
using Fornecedores.Domain.Interfaces.Services;
using Fornecedores.Domain.Service;
using Fornecedores.Infra.Data.MongoDB.Cache;
using Fornecedores.Infra.Data.MongoDB.Contexts;
using Fornecedores.Infra.Data.MongoDB.Settings;
using Fornecedores.Infra.Data.SqlServer.Contexts;
using Fornecedores.Infra.Data.SqlServer.Repositories;

namespace Fornecedores.Service.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection
(WebApplicationBuilder builder)
        {
            builder.Services.Configure<MongoDbSettings>
            (builder.Configuration.GetSection("MongoDbSettings"));
            builder.Services.AddTransient
       <IFornecedorAppService, FornecedorAppService>();
            builder.Services.AddTransient
            <IEnderecoDomainService, EnderecoDomainService>();
            builder.Services.AddTransient
            <IFornecedorDomainService, FornecedorDomainService>();
            builder.Services.AddTransient
            <IEnderecoRepository, EnderecoRepository>();
            builder.Services.AddTransient
            <IFornecedorRepository, FornecedorRepository>();
            builder.Services.AddTransient
            <IEnderecoCache, EnderecoCache>();
            builder.Services.AddTransient<IFornecedorCache, FornecedorCache>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<DataContext>();
            builder.Services.AddTransient<MongoDbContext>();
        }
    }
}
