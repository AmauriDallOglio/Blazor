using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Consulta
{
    public class ConsultaTenantMediatorRequest : IRequest<ConsultaTenantMediatorResponse>
    {
        public Guid Id { get; set; }
 
    }
}
