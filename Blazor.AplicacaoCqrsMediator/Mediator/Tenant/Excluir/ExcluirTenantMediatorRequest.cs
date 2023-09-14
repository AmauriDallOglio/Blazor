using Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Consulta;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Excluir
{
    public class ExcluirTenantMediatorRequest : IRequest<ExcluirTenantMediatorResponse>
    {
        public Guid Id { get; set; }
    }
}
