using AutoMapper;
using Fornecedores.Application.Interfaces;
using Fornecedores.Application.Models.Commands;
using Fornecedores.Application.Models.Queries;
using Fornecedores.Domain.Interfaces.Cache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Application.Services
{
    public class FornecedorAppService: IFornecedorAppService
    {
        private readonly IFornecedorCache? _fornecedorCache;
        private readonly IMediator? _mediator;
        private readonly IMapper? _mapper;

        public FornecedorAppService
        (IFornecedorCache? fornecedorCache, IMediator? mediator,
        IMapper? mapper)
        {
            _fornecedorCache = fornecedorCache;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<FornecedorQuery> Create(FornecedorCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<FornecedorQuery> Delete(FornecedorDeleteCommand command)
        {
            return await _mediator.Send(command);
        }

        public List<FornecedorQuery> GetAll()
        {
            return _mapper.Map<List<FornecedorQuery>>(_fornecedorCache.GetAll());
        }

        public FornecedorQuery? GetById(Guid id)
        {
            return _mapper.Map<FornecedorQuery>(_fornecedorCache.GetById(id));
        }

        public async Task<FornecedorQuery> Update(FornecedorUpdateCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
