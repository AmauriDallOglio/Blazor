using Blazor.Infra.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Infra.Context
{
    public class ConfiguracaoMapeamento
    {
        public static void Injetar(ModelBuilder builder)
        {
 
            builder.ApplyConfiguration(new AuditoriaMapeamento());
            builder.ApplyConfiguration(new TenantMapeamento());
        }
    }
}
