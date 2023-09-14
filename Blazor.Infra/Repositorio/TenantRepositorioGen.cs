using Blazor.Dominio.Entidade;
using Blazor.Dominio.InterfaceRepositorio;
using Blazor.Infra.Context;
using Blazor.Infra.Modelo;

namespace Blazor.Infra.Repositorio
{
    public class TenantRepositorioGen : RepositorioGenerico<Tenant>, ITenantRepositorioGen
    {
        private readonly MeuContext _contexto;
        public TenantRepositorioGen(MeuContext dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }
    }
}
