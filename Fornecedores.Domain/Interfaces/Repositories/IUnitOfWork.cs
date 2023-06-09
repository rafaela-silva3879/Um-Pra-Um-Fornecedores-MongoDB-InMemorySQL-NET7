using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        public IEnderecoRepository EnderecoRepository { get; }
        public IFornecedorRepository FornecedorRepository { get; }
    }
}
