using AutoMapper;
using Fornecedores.Application.Models.Commands;
using Fornecedores.Application.Models.Queries;
using Fornecedores.Application.Notifications;
using Fornecedores.Domain.Interfaces.Services;
using Fornecedores.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Application.RequestHandlers
{

    /// <summary>
    /// Classe para processar os eventos de
    ///cadastro, exclusão e edição de produtos
    /// </summary>
    public class FornecedorRequestHandler :
                        IRequestHandler<FornecedorCreateCommand, FornecedorQuery>,
                        IRequestHandler<FornecedorDeleteCommand, FornecedorQuery>,
                        IRequestHandler<FornecedorUpdateCommand, FornecedorQuery>
    {
        private readonly IFornecedorDomainService? _fornecedorRequestHandler;
        private readonly IEnderecoDomainService? _enderecoRequestHandler;
        private readonly IMapper? _mapper;
        private readonly IMediator? _mediator;

        public FornecedorRequestHandler(IFornecedorDomainService? fornecedorRequestHandler, IEnderecoDomainService? enderecoRequestHandler, IMapper? mapper, IMediator? mediator)
        {
            _fornecedorRequestHandler = fornecedorRequestHandler;
            _enderecoRequestHandler = enderecoRequestHandler;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<FornecedorQuery> Handle(FornecedorCreateCommand request,
        CancellationToken cancellationToken)
        {
            var f = new Fornecedor();
            f.IdFornecedor=Guid.NewGuid();
            f.Telefone = request.Telefone;
            f.Nome = request.Nome;
            f.CNPJ = request.CNPJ;
            f.IdEndereco=Guid.NewGuid();

            
            Endereco e = new Endereco();
            e.IdEndereco = f.IdEndereco.Value;
            e.Cep = request.Endereco.Cep;
            e.Logradouro = request.Endereco.Logradouro;
            e.Numero = request.Endereco.Numero;
            e.Complemento = request.Endereco.Complemento;
            e.Bairro = request.Endereco.Bairro;
            e.Cidade = request.Endereco.Cidade;
            e.Estado = request.Endereco.Estado;

            _fornecedorRequestHandler.Inserir(f);
            _enderecoRequestHandler.Inserir(e);
            
            await _mediator.Publish(new FornecedorNotification { 
                Fornecedor = f,
                Notification=ActionNotification.Create
            });

            await _mediator.Publish(new EnderecoNotification
            {
                Endereco = e,
                Notification = ActionNotification.Create
            });

            //return Task.CompletedTask;
            var query = _mapper.Map<FornecedorQuery>(f);
            query.Endereco= _mapper.Map<EnderecoQuery>(e);

            return query;

        }
        public async Task<FornecedorQuery> Handle(FornecedorDeleteCommand request,
        CancellationToken cancellationToken)
        {
            try
            {
                var f = _fornecedorRequestHandler.ObterPorId(request.IdFornecedor.Value);
                _fornecedorRequestHandler.Excluir(f);

                await _mediator.Publish(new FornecedorNotification
                {
                    Fornecedor= f,
                    Notification=ActionNotification.Delete
                });

                var e = _enderecoRequestHandler.ObterPorId(f.IdEndereco.Value);
                _enderecoRequestHandler.Excluir(e);
                await _mediator.Publish(new EnderecoNotification
                {
                    Endereco = e,
                    Notification = ActionNotification.Delete
                });

                var query = _mapper.Map<FornecedorQuery>(f);
                return query;
                // return Task.CompletedTask;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<FornecedorQuery> Handle(FornecedorUpdateCommand request,
        CancellationToken cancellationToken)
        {
            var f = _fornecedorRequestHandler.ObterPorId(request.IdFornecedor.Value);
            f.Telefone = request.Telefone;
            f.Nome = request.Nome;
            f.CNPJ = request.CNPJ;
            f.IdEndereco = request.IdEndereco;

            var e = new Endereco();
            e = _enderecoRequestHandler.ObterPorId(request.IdEndereco.Value);

            e.Logradouro= request.Endereco.Logradouro;
            e.Numero = request.Endereco.Numero;
            e.Complemento = request.Endereco.Complemento;
            e.Bairro = request.Endereco.Bairro;
            e.Cidade = request.Endereco.Cidade;
            e.Estado=request.Endereco.Estado;

            _fornecedorRequestHandler.Alterar(f);
            _enderecoRequestHandler.Alterar(e);
            await _mediator.Publish(new FornecedorNotification
            {
                Fornecedor = f,
                Notification = ActionNotification.Update
            }) ;


            await _mediator.Publish(new EnderecoNotification
            {
                Endereco = e,
                Notification = ActionNotification.Update
            });

            var query = _mapper.Map<FornecedorQuery>(f);
            query.Endereco=_mapper.Map<EnderecoQuery>(e);
            return query;
        }
    }
}