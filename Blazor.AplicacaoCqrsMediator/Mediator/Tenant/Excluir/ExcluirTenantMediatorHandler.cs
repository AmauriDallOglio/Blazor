using AutoMapper;
using Blazor.Aplicacao.Util;
using Blazor.AplicacaoCqrsMediator.Mediator.Auditoria.Inserir;
using Blazor.Dominio.InterfaceRepositorio;
using Blazor.Dominio.Util;
using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Excluir
{
    public class ExcluirTenantMediatorHandler : IRequestHandler<ExcluirTenantMediatorRequest, ExcluirTenantMediatorResponse>
    {
        private readonly ITenantRepositorioGen _iTenantRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ExcluirTenantMediatorHandler(IMapper mapper, IMediator mediator, ITenantRepositorioGen repository)
        {
            _iTenantRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ExcluirTenantMediatorResponse> Handle(ExcluirTenantMediatorRequest request,  CancellationToken cancellationToken)
        {
            var tenant = _iTenantRepositorio.ObterPorId(request.Id);
            InserirLogAuditoria(tenant.Id, tenant.Id);
            var resultado = _iTenantRepositorio.Deletar(tenant);

            ExcluirTenantMediatorResponse retorno = _mapper.Map<ExcluirTenantMediatorResponse>(resultado);
            return await Task.FromResult(retorno);
        }

        private async Task InserirLogAuditoria(Guid idTenante, Guid idRegistroAtual)
        {
            InserirAuditoriaRequest auditoria = new InserirAuditoriaRequest { IdTenant = idTenante, IdRegistro = idRegistroAtual, NomeTabela = "Tenant", ModoCrud = (short)ModoCruds.Excluir };
            await _mediator.Send(auditoria);
        }

    }
}
