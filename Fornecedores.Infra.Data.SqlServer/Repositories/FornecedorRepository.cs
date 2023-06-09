using Fornecedores.Domain.Interfaces.Repositories;
using Fornecedores.Domain.Models;
using Fornecedores.Infra.Data.SqlServer.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Infra.Data.SqlServer.Repositories
{
    public class FornecedorRepository
: BaseRepository<Fornecedor, Guid>, IFornecedorRepository
    {
        private readonly DataContext? _dataContext;
        public FornecedorRepository(DataContext? dataContext)
        : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override List<Fornecedor> GetAll()
        {
            return _dataContext
                .Fornecedores
                .Include(f => f.Endereco) //JOIN
                .ToList();
        }
        public override Fornecedor GetById(Guid id)
        {
            return _dataContext
            .Fornecedores
            .Include(f => f.Endereco) //JOIN
            .FirstOrDefault(f => f.IdFornecedor == id);
        }
    }
}
