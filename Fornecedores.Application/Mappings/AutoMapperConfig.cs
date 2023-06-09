using AutoMapper;
using Fornecedores.Application.Models.Queries;
using Fornecedores.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Application.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorQuery>();
            CreateMap<Endereco, EnderecoQuery>();
        }
    }
}
