using Fornecedores.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Domain.Interfaces.Services
{
    public interface IFornecedorDomainService
        : IBaseDomainService<Fornecedor, Guid>
    {
    }
}
