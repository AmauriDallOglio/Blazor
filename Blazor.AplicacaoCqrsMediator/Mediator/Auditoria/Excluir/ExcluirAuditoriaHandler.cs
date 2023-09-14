using AutoMapper;
using Blazor.Dominio.InterfaceRepositorio;
using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Auditoria.Excluir
{
    public class ExcluirAuditoriaHandler : IRequestHandler<ExcluirAuditoriaRequest, ExcluirAuditoriaResponse>
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IAuditoriaRepositorio _iAuditoriaRepositorio;
 

        public ExcluirAuditoriaHandler(IAuditoriaRepositorio iAuditoriaRepositorio, IMediator mediator, IMapper mapper)
        {
            _iAuditoriaRepositorio = iAuditoriaRepositorio;
            _mediator = mediator;
            _mapper = mapper;
        }


        public Task<ExcluirAuditoriaResponse> Handle(ExcluirAuditoriaRequest request, CancellationToken cancellationToken)
        {
            var entidade = _mapper.Map<Dominio.Entidade.Auditoria>(request);
            entidade.DadosDoExcluir(request.IdTenant, request.IdRegistro, request.NomeTabela);
            var auditoriaBD = _iAuditoriaRepositorio.Incluir(entidade);
            ExcluirAuditoriaResponse dto = _mapper.Map<ExcluirAuditoriaResponse>(auditoriaBD);
            return Task.FromResult(dto);
        }
    }
}
