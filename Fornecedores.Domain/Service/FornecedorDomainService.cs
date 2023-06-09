using Fornecedores.Domain.Interfaces.Repositories;
using Fornecedores.Domain.Interfaces.Services;
using Fornecedores.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Fornecedores.Domain.Service.FornecedorDomainService;

namespace Fornecedores.Domain.Service
{
    public class FornecedorDomainService
     : BaseDomainService
<Fornecedor, Guid>, IFornecedorDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;
        public FornecedorDomainService(IUnitOfWork? unitOfWork)
        : base(unitOfWork.FornecedorRepository)
        {
            _unitOfWork = unitOfWork;
        }


        public override void Inserir(Fornecedor entity)
        {
            _unitOfWork.FornecedorRepository.Add(entity);
            entity.Endereco = _unitOfWork.EnderecoRepository
            .GetById(entity.IdEndereco.Value);
        }
        public override void Alterar(Fornecedor entity)
        {
            _unitOfWork.FornecedorRepository.Update(entity);
            entity.Endereco = _unitOfWork.EnderecoRepository
            .GetById(entity.IdEndereco.Value);
        }
        public override void Excluir(Fornecedor entity)
        {
            _unitOfWork.FornecedorRepository.Delete(entity);
            entity.Endereco = _unitOfWork.EnderecoRepository
            .GetById(entity.IdEndereco.Value);
        }
    }
}

