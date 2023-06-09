using Fornecedores.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Domain.Interfaces.Cache
{
    public interface IFornecedorCache : IBaseCache<Fornecedor, Guid>
    {
    }
}