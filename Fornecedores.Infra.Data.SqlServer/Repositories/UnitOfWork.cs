using Fornecedores.Domain.Interfaces.Repositories;
using Fornecedores.Infra.Data.SqlServer.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Infra.Data.SqlServer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext? _dataContext;
        private IDbContextTransaction _transaction;
        public UnitOfWork(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }
        public void BeginTransaction()
        {
            _transaction = _dataContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
        }
        public void Rollback()
        {
            _transaction.Rollback();
        }
        public IEnderecoRepository EnderecoRepository
        => new EnderecoRepository(_dataContext);

        public IFornecedorRepository FornecedorRepository
        => new FornecedorRepository(_dataContext); 
        
        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}