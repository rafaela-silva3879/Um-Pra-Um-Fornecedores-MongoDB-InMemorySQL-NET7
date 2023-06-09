using Fornecedores.Application.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Application.Models.Commands
{
    /// <summary>
    /// Modelo de dados para a ação de exclusão de endereço
    /// </summary>
    public class EnderecoDeleteCommand : IRequest<EnderecoQuery>
    {
        public Guid? IdEndereco { get; set; }
    }
}
