using Blazor.Dominio.Entidade;
using Blazor.Dominio.InterfaceRepositorio;
using Blazor.Infra.Context;
using Blazor.Infra.Modelo;

namespace Blazor.Infra.Repositorio
{
    public class AuditoriaRepositorioGen : RepositorioGenerico<Auditoria>, IAuditoriaRepositorioGen
    {
        private readonly MeuContext _contexto;
        public AuditoriaRepositorioGen(MeuContext dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }


    }
}
