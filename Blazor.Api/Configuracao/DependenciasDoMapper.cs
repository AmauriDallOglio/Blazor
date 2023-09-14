using AutoMapper;
using Blazor.AplicacaoCqrsMediator.Mediator.Auditoria.Inserir;
using Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Alterar;
using Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Consulta;
using Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Excluir;
using Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Inserir;
using Blazor.Dominio.Entidade;
using Blazor.Dominio.Validador;

namespace Blazor.Api.Configuracao
{
    public static class DependenciasDoMapper
    {
        public static void Injetar(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Tenant, ConsultaTenantMediatorResponse>().ReverseMap();
            cfg.CreateMap<Tenant, ConsultaTenantListaTodosResponse>().ReverseMap();

            cfg.CreateMap<Tenant, InserirTenantMediatorResponse>().ReverseMap();
            cfg.CreateMap<Tenant, InserirTenantMediatorRequest>().ReverseMap();

            cfg.CreateMap<Tenant, ExcluirTenantMediatorResponse>().ReverseMap();
            cfg.CreateMap<Tenant, ExcluirTenantMediatorRequest>().ReverseMap();

            cfg.CreateMap<Tenant, AlterarTenantMediatorResponse>().ReverseMap();
            cfg.CreateMap<Tenant, AlterarTenantMediatorRequest>().ReverseMap();



            cfg.CreateMap<Auditoria, InserirAuditoriaRequest>().ReverseMap();
            cfg.CreateMap<Auditoria, InserirAuditoriaResponse>().ReverseMap();


        }
    }
}
