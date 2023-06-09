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
    /// Modelo de dados para a ação de cadastro de fornecedor
    /// </summary>
    public class FornecedorCreateCommand : IRequest<FornecedorQuery>
    {
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? Telefone { get; set; }
        public EnderecoCreateCommand? Endereco { get; set; }
    

    }
}
