using AutoMapper;
using Blazor.Aplicacao.Util;
using Blazor.AplicacaoCqrsMediator.Mediator.Auditoria.Inserir;
using Blazor.Dominio.InterfaceRepositorio;
using Blazor.Dominio.Util;
using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Alterar
{
    public class AlterarTenantMediatorHandler : IRequestHandler<AlterarTenantMediatorRequest, AlterarTenantMediatorResponse>
    {
        private readonly ITenantRepositorioGen _iTenantRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AlterarTenantMediatorHandler(IMediator mediator, IMapper mapper, ITenantRepositorioGen repository)
        {
            _iTenantRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<AlterarTenantMediatorResponse> Handle(AlterarTenantMediatorRequest request, CancellationToken cancellationToken)
        {
            var entidadeMapeada = _mapper.Map<Dominio.Entidade.Tenant>(request);
            Dominio.Entidade.Tenant tenant = _iTenantRepositorio.Alterar(entidadeMapeada, true);
            InserirLogAuditoria(tenant.Id, tenant.Id);
            var resultado = _mapper.Map<AlterarTenantMediatorResponse>(tenant);
            return await Task.FromResult(resultado);
        }

        private async Task InserirLogAuditoria(Guid idTenante, Guid idRegistroAtual)
        {
            InserirAuditoriaRequest auditoria = new InserirAuditoriaRequest { IdTenant = idTenante, IdRegistro = idRegistroAtual, NomeTabela = "Tenant", ModoCrud = (short)ModoCruds.Alterar };
            await _mediator.Send(auditoria);
        }

    }
}
