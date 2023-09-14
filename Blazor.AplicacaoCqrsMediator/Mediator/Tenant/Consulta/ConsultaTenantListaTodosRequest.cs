using Blazor.Dominio.Modelo;
using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Consulta
{
    public class ConsultaTenantListaTodosRequest :  IRequest<RetornoPaginadoGenerico<ConsultaTenantListaTodosResponse>>
    {
        public string Descricao { get; set; } 
    }
}
