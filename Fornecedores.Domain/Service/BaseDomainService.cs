using Fornecedores.Domain.Interfaces.Repositories;
using Fornecedores.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Domain.Service
{
    public class BaseDomainService<TEntity, TKey>
: IBaseDomainService<TEntity, TKey>
where TEntity : class
    {
        private readonly IBaseRepository<TEntity, TKey> _baseRepository;
        protected BaseDomainService
        (IBaseRepository<TEntity, TKey> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual void Inserir(TEntity entity)
        {
            _baseRepository.Add(entity);
        }
        public virtual void Alterar(TEntity entity)
        {
            _baseRepository.Update(entity);
        }
        public virtual void Excluir(TEntity entity)
        {
            _baseRepository.Delete(entity);
        }
        public virtual List<TEntity> ObterTodos()
        {
            return _baseRepository.GetAll();
        }
        public virtual TEntity ObterPorId(TKey id)
        {
            return _baseRepository.GetById(id);
        }
        public virtual void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}