using Blazor.Dominio.Entidade;
using Blazor.Dominio.InterfaceRepositorio;
using Blazor.Infra.Context;

namespace Blazor.Infra.Repositorio
{
    public class AuditoriaRepositorio : IAuditoriaRepositorio
    {

        private readonly MeuContext _context;
        public AuditoriaRepositorio(MeuContext bancoContext)
        {
            _context = bancoContext;
        }

        public Auditoria Incluir(Auditoria auditoria)
        {
            try
            {
                var resultadoAdd = _context.Auditoria.Add(auditoria);
                var resuldadoSalva = _context.SaveChanges();
                return auditoria;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Repositorio:{erro.Message} / {erro.InnerException.Message}");
            }
        }

        public Auditoria Alterar(Auditoria auditoria)
        {
            throw new NotImplementedException();
        }

        public Auditoria BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Auditoria> BuscarTodos()
        {
            var retornoBD = _context.Auditoria.ToList();
            return retornoBD;
        }

        public Auditoria Excluir(Auditoria auditoria)
        {
            throw new NotImplementedException();
        }

        public List<Auditoria> BuscarPorIdTenant(Guid idTenant)
        {
            var retornoBD = _context.Auditoria.Where(a => a.Id_Tenant == idTenant).ToList();
            return retornoBD;
        }
    }
}
