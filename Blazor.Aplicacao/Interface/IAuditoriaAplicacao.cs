using Blazor.Aplicacao.DTO;
using Blazor.Dominio.Entidade;

namespace Blazor.Aplicacao.Interface
{
    public interface IAuditoriaAplicacao
    {
        public Auditoria IncluirAuditoria(Guid tenant, Guid id_Registro);
        public AuditoriaApiListaOut ListarTodos();
        public List<AuditoriaDTO> ConvertEntidadeEmDTO(List<AuditoriaDTO> listaDto);
    }
}
