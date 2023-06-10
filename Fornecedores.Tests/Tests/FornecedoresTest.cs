using Bogus;
using FluentAssertions;
using Fornecedores.Application.Models.Commands;
using Fornecedores.Application.Models.Queries;
using Fornecedores.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fornecedores.Tests.Tests
{
    public class FornecedoresTest
    {
        private readonly string? _endpoint;
        private readonly Faker? _faker;

        public FornecedoresTest()
        {
            _endpoint = "api/fornecedores";
            _faker = new Faker("pt_BR");
        }

        [Fact]
        public async Task<FornecedorQuery> Test_Post_Fornecedores_Returns_Created()
        {
            var request = new FornecedorCreateCommand();
            request.CNPJ = "4567890987667";
            request.Nome = "Fornecedor Um";
            request.Telefone = "21678956789";

            request.Endereco = new EnderecoCreateCommand();
            request.Endereco.Bairro = "Teste Bairro";
            request.Endereco.Cep = "345678989";
            request.Endereco.Cidade = "Cidade Teste";
            request.Endereco.Complemento = "Complemento Teste";
            request.Endereco.Cidade = "Rio de Janeiro";
            request.Endereco.Estado = "RJ";
            request.Endereco.Logradouro = "Logradouro Teste";
            request.Endereco.Numero = "1";


            var client = TestHelper.CreateClient;

            var result = await client.PostAsync(_endpoint,
            TestHelper.CreateContent(request));

            var response = TestHelper.ReadResponse<FornecedorQuery>(result);

            result.StatusCode.Should().Be(HttpStatusCode.Created);

            response.IdFornecedor.Should().NotBeNull();
            response.Nome.Should().Be(request.Nome);
            response.Endereco.Should().NotBeNull();
            response.Endereco.IdEndereco.Should().NotBeNull();
            response.Endereco.IdEndereco.Should().Be(response.IdEndereco);
            response.Endereco.Logradouro.Should().Be(request.Endereco.Logradouro);

            return response;
        }

        [Fact]
        public async Task Test_Put_Fornecedores_Returns_Ok()
        {
            var f = await Test_Post_Fornecedores_Returns_Created();
            var request = new FornecedorUpdateCommand();

            request.IdFornecedor = request.IdFornecedor;
            request.CNPJ = f.CNPJ;
            request.Nome = f.Nome;
            request.Telefone = f.Telefone;
            request.IdEndereco = f.IdEndereco;


            request.Endereco = new EnderecoUpdateCommand();
            request.Endereco.IdEndereco = f.IdEndereco;
            request.Endereco.Bairro = f.Endereco.Bairro;
            request.Endereco.Cep = f.Endereco.Cep;
            request.Endereco.Cidade = f.Endereco.Cidade;
            request.Endereco.Complemento = f.Endereco.Complemento;
            request.Endereco.Cidade = f.Endereco.Cidade;
            request.Endereco.Estado = f.Endereco.Estado;
            request.Endereco.Logradouro = f.Endereco.Logradouro;
            request.Endereco.Numero = f.Endereco.Numero;

            var client = TestHelper.CreateClient;
            var result = await client.PutAsync(_endpoint, TestHelper.CreateContent(request));

            var response = TestHelper.ReadResponse<FornecedorQuery>(result);

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            response.IdFornecedor.Should().Be(request.IdFornecedor);
            response.Nome.Should().Be(request.Nome);
            response.Endereco.Should().NotBeNull();
            response.IdEndereco.Should().Be(request.IdEndereco);
            response.Endereco.IdEndereco.Should().Be(request.IdEndereco);

            response.Endereco.Logradouro.Should().Be(request.Endereco.Logradouro);
        }

        [Fact]
        public async Task Test_Delete_Fornecedores_Returns_Ok()
        {
            var f = await Test_Post_Fornecedores_Returns_Created();
            var client = TestHelper.CreateClient;

            var result = await client.DeleteAsync(_endpoint + "/" + f.IdFornecedor);

            var response = TestHelper.ReadResponse<FornecedorQuery>(result);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            response.IdFornecedor.Should().Be(f.IdFornecedor);
            response.Nome.Should().Be(f.Nome);
        }

        [Fact]
        public async Task Test_GetAll_Fornecedores_Returns_Ok()
        {
            var f = await Test_Post_Fornecedores_Returns_Created();

            var client = TestHelper.CreateClient;

            var result = await client.GetAsync(_endpoint);

            var response = TestHelper.ReadResponse<List<FornecedorQuery>>(result);

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var fornecedorCadastrado = response.FirstOrDefault(x => x.IdFornecedor == f.IdFornecedor);

            fornecedorCadastrado.IdFornecedor.Should().Be(f.IdFornecedor);
            fornecedorCadastrado.Endereco.IdEndereco.Should().Be(f.Endereco.IdEndereco);
            fornecedorCadastrado.Nome.Should().Be(f.Nome);
            fornecedorCadastrado.Endereco.Logradouro.Should().Be(f.Endereco.Logradouro);


        }

        [Fact]
        public async Task Test_GetById_Fornecedores_Returns_Ok()
        {
            var f = await Test_Post_Fornecedores_Returns_Created();

            var client = TestHelper.CreateClient;
           
            var result = await client.GetAsync(_endpoint + "/" + f.IdFornecedor);

            var response = TestHelper.ReadResponse<FornecedorQuery>(result);

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            response.IdFornecedor.Should().Be(f.IdFornecedor);
            response.Nome.Should().Be(f.Nome);
            response.Endereco.IdEndereco.Should().Be(f.Endereco.IdEndereco);
            response.Endereco.Logradouro.Should().Be(f.Endereco.Logradouro);

        }
    }
}
