using Fornecedores.Application.Models.Commands;
using Fornecedores.Application.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Application.Interfaces
{
    public interface IFornecedorAppService
    {
        Task<FornecedorQuery> Create(FornecedorCreateCommand command);
        Task<FornecedorQuery> Update(FornecedorUpdateCommand command);
        Task<FornecedorQuery> Delete(FornecedorDeleteCommand command);
        List<FornecedorQuery> GetAll();
        FornecedorQuery? GetById(Guid id);
    }
}
