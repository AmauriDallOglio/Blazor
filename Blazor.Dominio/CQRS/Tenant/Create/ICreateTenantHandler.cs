using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Dominio.Commands.Tenant.Create
{
    public interface ICreateTenantHandler
    {
        CreateTenantResponse Handle(CreateTenantRequest request);
    }
}
