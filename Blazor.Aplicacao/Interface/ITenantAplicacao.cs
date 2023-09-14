using Blazor.Aplicacao.DTO;

namespace Blazor.Aplicacao.Interface
{
    public interface ITenantAplicacao  
    {
        public TenantApiOut ObterPorId(Guid id);
        public TenantApiListaOut ListarTodos();
        public TenantApiOut Incluir(TenantApiIncluir apiIn);
        public List<TenantDTO> ConvertEntidadeEmDTO(List<TenantDTO> listaDto);

    }
}
