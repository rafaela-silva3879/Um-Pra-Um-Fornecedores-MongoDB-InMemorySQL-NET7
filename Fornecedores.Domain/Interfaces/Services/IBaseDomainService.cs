using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity, TKey> : IDisposable
where TEntity : class
    {
        void Inserir(TEntity entity);
        void Alterar(TEntity entity);
        void Excluir(TEntity entity);
        List<TEntity> ObterTodos();
        TEntity ObterPorId(TKey id);
    }
}