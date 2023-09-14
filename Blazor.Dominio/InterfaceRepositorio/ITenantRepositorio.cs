using Blazor.Dominio.Entidade;

namespace Blazor.Dominio.InterfaceRepositorio
{
    public interface ITenantRepositorio
    {


        Tenant Incluir(Tenant tenant);
        Tenant Alterar(Tenant tenant);
        Tenant Excluir(Tenant tenant);
        Tenant BuscarPorId(Guid Id);
        List<Tenant> BuscarTodos();
        List<Tenant> BuscarTodosPorDescricao(string descricao);

    }
}
