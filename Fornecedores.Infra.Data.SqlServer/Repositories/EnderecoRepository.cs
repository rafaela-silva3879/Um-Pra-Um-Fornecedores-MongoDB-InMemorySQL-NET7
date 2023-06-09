using Fornecedores.Domain.Interfaces.Repositories;
using Fornecedores.Domain.Models;
using Fornecedores.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Infra.Data.SqlServer.Repositories
{
    public class EnderecoRepository
    : BaseRepository<Endereco, Guid>, IEnderecoRepository
    {
        private readonly DataContext? _dataContext;
        public EnderecoRepository(DataContext? dataContext)
        : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
