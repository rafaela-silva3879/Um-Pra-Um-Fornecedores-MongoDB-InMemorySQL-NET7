using Fornecedores.Application.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Application.Models.Queries
{
    public class FornecedorQuery
    {
        public Guid? IdFornecedor { get; set; }
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? Telefone { get; set; }
        public Guid? IdEndereco { get; set; }
        public EnderecoQuery? Endereco { get; set; }
    }
}
