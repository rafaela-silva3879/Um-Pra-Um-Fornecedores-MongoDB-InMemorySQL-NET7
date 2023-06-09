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
    /// Modelo de dados para a ação de edição de fornecedor
    /// </summary>
    public class FornecedorUpdateCommand : IRequest<FornecedorQuery>
    {
        public Guid? IdFornecedor { get; set; }
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? Telefone { get; set; }
        public Guid? IdEndereco { get; set; }

        public EnderecoUpdateCommand? Endereco { get; set; }

    }
}
