using Blazor.Dominio.Modelo;
using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Inserir
{
    public class InserirTenantMediatorRequest : IRequest<ResultadoOperacao<InserirTenantMediatorResponse>>
    {
        public string Referencia { get; set; }
        public string Descricao { get; set; }
 
    }
}
