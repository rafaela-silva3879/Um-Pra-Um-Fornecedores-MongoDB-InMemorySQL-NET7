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
    /// Modelo de dados para a ação de edição de endereço
    /// </summary>
    public class EnderecoUpdateCommand : IRequest<EnderecoQuery>
    {
        public Guid? IdEndereco { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Cep { get; set; }
    }
}
