using Fornecedores.Domain.Interfaces.Repositories;
using Fornecedores.Domain.Interfaces.Services;
using Fornecedores.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Domain.Service
{
    public class EnderecoDomainService : BaseDomainService
<Endereco, Guid>, IEnderecoDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public EnderecoDomainService(IUnitOfWork? unitOfWork)
            : base(unitOfWork.EnderecoRepository)
        {
            _unitOfWork = unitOfWork;
        }






    }
}
