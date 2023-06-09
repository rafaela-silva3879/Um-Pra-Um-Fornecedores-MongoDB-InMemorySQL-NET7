using Fornecedores.Application.Interfaces;
using Fornecedores.Application.Models.Commands;
using Fornecedores.Application.Models.Queries;
using Fornecedores.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fornecedores.Service.Controllers
{
    [Route("api/fornecedores")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorAppService? _fornecedorAppService;

        public FornecedoresController(IFornecedorAppService? fornecedorAppService)
        {
            _fornecedorAppService = fornecedorAppService;
        }

        /// <summary>
        /// Serviço para a criação de fornecedor e seu endereço.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Retorna os dados do fornecedor inserido.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(FornecedorQuery), 201)]
        public async Task<IActionResult> Post(FornecedorCreateCommand command)
        {
            return StatusCode(201, await _fornecedorAppService.Create(command));
        }
        /// <summary>
        /// Serviço de atualização de Fornecedor e seu endereço.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Retorna os dados do fornecedor atualizado.</returns>
        [HttpPut]
        [ProducesResponseType(typeof(FornecedorQuery), 200)]
        public async Task<IActionResult> Put(FornecedorUpdateCommand command)
        {
            return StatusCode(200, await _fornecedorAppService.Update(command));
        }

        /// <summary>
        /// Serviço de exclusão de fornecedor e seu endereço.
        /// </summary>
        /// <param name="id">id do fornecedor</param>
        /// <returns>Retorna os dados do fornecedor excluído.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FornecedorQuery), 200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new FornecedorDeleteCommand { IdFornecedor = id };
            return StatusCode(200, await _fornecedorAppService.Delete(command));
        }

        /// <summary>
        /// Serviço que busca fornecedores.
        /// </summary>
        /// <returns>retorna uma lista de todos os fornecedores com seus endereços.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<FornecedorQuery>), 200)]
        public IActionResult GetAll()
        {
            return StatusCode(200, _fornecedorAppService.GetAll());
        }

        /// <summary>
        /// Serviço que busca fornecedor.
        /// </summary>
        /// <param name="id">Id do fornecedor.</param>
        /// <returns>Retorna os dados do fornecedor com seu endereço.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FornecedorQuery), 200)]
        public IActionResult GetById(Guid id)
        {
            return StatusCode(200, _fornecedorAppService.GetById(id));
        }
    }
}
