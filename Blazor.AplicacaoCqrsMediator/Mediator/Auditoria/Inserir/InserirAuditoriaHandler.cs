using AutoMapper;
using Blazor.Dominio.Util;
using Blazor.Dominio.InterfaceRepositorio;
using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Auditoria.Inserir
{
    public class InserirAuditoriaHandler : IRequestHandler<InserirAuditoriaRequest, InserirAuditoriaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IAuditoriaRepositorioGen _iAuditoriaRepositorio;

        public InserirAuditoriaHandler(IAuditoriaRepositorioGen iAuditoriaRepositorio, IMediator mediator, IMapper mapper)
        {
            _iAuditoriaRepositorio = iAuditoriaRepositorio;
            _mediator = mediator;
            _mapper = mapper;
        }

        public Task<InserirAuditoriaResponse> Handle(InserirAuditoriaRequest request, CancellationToken cancellationToken)
        {
            var entidade = _mapper.Map<Dominio.Entidade.Auditoria>(request);
            switch (request.ModoCrud)
            {
                case (short)ModoCruds.Inserir:
                    entidade.DadosDoIncluir(request.IdTenant, request.IdRegistro, request.NomeTabela);
                    break;
                case (short)ModoCruds.Alterar:
                    entidade.DadosDoAlterar(request.IdTenant, request.IdRegistro, request.NomeTabela);
                    break;
                case (short)ModoCruds.Excluir:
                    entidade.DadosDoExcluir(request.IdTenant, request.IdRegistro, request.NomeTabela);
                    break;
            }
            var auditoriaBD = _iAuditoriaRepositorio.Inserir(entidade, true);
            InserirAuditoriaResponse dto = _mapper.Map<InserirAuditoriaResponse>(auditoriaBD);
            return Task.FromResult(dto);
        }
    }
}
