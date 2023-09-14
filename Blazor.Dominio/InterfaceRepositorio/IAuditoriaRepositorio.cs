using Blazor.Dominio.Entidade;

namespace Blazor.Dominio.InterfaceRepositorio
{
    public interface IAuditoriaRepositorio
    {
        Auditoria Incluir(Auditoria auditoria);
        Auditoria Alterar(Auditoria auditoria);
        Auditoria Excluir(Auditoria auditoria);
        Auditoria BuscarPorId(Guid Id);
        List<Auditoria> BuscarPorIdTenant(Guid idTenant);
        List<Auditoria> BuscarTodos();
    }
}
