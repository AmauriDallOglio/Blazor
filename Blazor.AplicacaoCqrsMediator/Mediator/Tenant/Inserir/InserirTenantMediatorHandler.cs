using AutoMapper;
using Blazor.AplicacaoCqrsMediator.Mediator.Auditoria.Inserir;
using Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Interface;
using Blazor.Dominio.InterfaceRepositorio;
using Blazor.Dominio.Modelo;
using Blazor.Dominio.Util;
using Blazor.Dominio.Validador;
using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Inserir
{
    public class InserirTenantMediatorHandler : IRequestHandler<InserirTenantMediatorRequest, ResultadoOperacao<InserirTenantMediatorResponse>>, ITenantMediatorInserir
    {
        private readonly ITenantRepositorioGen _iTenantRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InserirTenantMediatorHandler(IMediator mediator, IMapper mapper, ITenantRepositorioGen repository)
        {
            _iTenantRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<InserirTenantMediatorResponse>> Handle(InserirTenantMediatorRequest request, CancellationToken cancellationToken)
        {

            var resultadoOperacao = CriarResultadoOperacao();

           var entidade = _mapper.Map<Dominio.Entidade.Tenant>(request);

            var validador = ValidaMapeamento(entidade);
            if (validador.Sucesso == false)
            {
                resultadoOperacao.Sucesso = validador.Sucesso;
                resultadoOperacao.Mensagem = validador.Mensagem;
                return Task.FromResult(resultadoOperacao);
            }

            var entidadeBD = _iTenantRepositorio.Inserir(entidade, true);
            var dto = _mapper.Map<InserirTenantMediatorResponse>(entidadeBD);
            resultadoOperacao.Modelo = dto;

            InserirAuditoria(dto.Id, dto.Id);

            return Task.FromResult(resultadoOperacao);
        }

        public async Task InserirAuditoria(Guid idTenante, Guid idRegistroAtual)
        {
            InserirAuditoriaRequest auditoria = new InserirAuditoriaRequest { IdTenant = idTenante, IdRegistro = idRegistroAtual, NomeTabela = "Tenant", ModoCrud = (short)ModoCruds.Inserir };
            _mediator.Send(auditoria);
        }

        public ResultadoOperacao<InserirTenantMediatorResponse> CriarResultadoOperacao()
        {
            ResultadoOperacao<InserirTenantMediatorResponse> resultadoOperacao = new ResultadoOperacao<InserirTenantMediatorResponse>(null)
            {
                Sucesso = true,
                Mensagem = ""
            };
            return resultadoOperacao;
        }

        public ResultadoOperacao<Dominio.Entidade.Tenant> ValidaMapeamento(Dominio.Entidade.Tenant entidade)
        {
            ResultadoOperacao<Dominio.Entidade.Tenant> validador = new TenantValidador().Validar(entidade);
            return validador;
        }
    }
}
