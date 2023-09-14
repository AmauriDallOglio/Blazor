using Blazor.Dominio.Entidade;
using Blazor.Dominio.InterfaceRepositorio;
using Blazor.Infra.Context;

namespace Blazor.Infra.Repositorio
{
    public class TenantRepositorio : ITenantRepositorio
    {
        private readonly MeuContext _context;
        public TenantRepositorio(MeuContext bancoContext)
        {
            _context = bancoContext;
        }

        public Tenant Incluir(Tenant tenant)
        {
            var resultadoAdd = _context.Tenant.Add(tenant);
            var resuldadoSalva = _context.SaveChanges();

            return tenant;
        }

        public Tenant Alterar(Tenant tenant)
        {
            _context.Tenant.Update(tenant);
            _context.SaveChanges();
            return tenant;
        }

        public Tenant Excluir(Tenant tenant)
        {
            _context.Tenant.Remove(tenant);
            _context.SaveChanges();
            return tenant;
        }

        public Tenant BuscarPorId(Guid id)
        {
            var resultado = _context.Tenant.Where(b => b.Id == id).FirstOrDefault();
            return resultado;
        }

        public List<Tenant> BuscarTodos()
        {
            var retornoBD = _context.Tenant.ToList();
            return retornoBD;
        }

        public List<Tenant> BuscarTodosPorDescricao(string descricao)
        {
            var resultado = _context.Tenant.Where(b => b.Descricao.Contains(descricao)).ToList();
            return resultado;
        }
    }
}
