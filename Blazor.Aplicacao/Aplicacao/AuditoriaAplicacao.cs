using Blazor.Aplicacao.DTO;
using Blazor.Aplicacao.Interface;
using Blazor.Dominio.Entidade;
using Blazor.Dominio.InterfaceRepositorio;

namespace Blazor.Aplicacao.Aplicacao
{
    public class AuditoriaAplicacao : IAuditoriaAplicacao
    {
        private readonly IAuditoriaRepositorio _iAuditoriaRepositorio;
        public AuditoriaAplicacao(IAuditoriaRepositorio iAuditoriaRepositorio)
        {
            _iAuditoriaRepositorio = iAuditoriaRepositorio;
        }

        public Auditoria IncluirAuditoria(Guid tenant, Guid id_Registro)
        {
            Auditoria auditoria = new Auditoria();
            auditoria = auditoria.DadosDoIncluir(tenant, id_Registro, "Tenant");
            Auditoria resultadoInfra = _iAuditoriaRepositorio.Incluir(auditoria);
            return auditoria;
        }

        public AuditoriaApiListaOut ListarTodos()
        {
            List<AuditoriaDTO> listaDto = new List<AuditoriaDTO>();
            listaDto = ConvertEntidadeEmDTO(listaDto);
            AuditoriaApiListaOut listaRetornoApi = new AuditoriaApiListaOut();
            listaRetornoApi.RetornaLista(listaDto, 201, "(GET) Listado com sucesso", "Listado com sucesso");
            return listaRetornoApi;
        }

        public List<AuditoriaDTO> ConvertEntidadeEmDTO(List<AuditoriaDTO> listaDto)
        {
            AudiotoriaApiOut retornoDto = new AudiotoriaApiOut();
            var listaRepositorio = _iAuditoriaRepositorio.BuscarTodos();
            foreach (Auditoria item in listaRepositorio)
            {
                retornoDto.ConvertEntidadeEmDTO(item, 0, "", "");
                listaDto.Add(retornoDto.Auditoria);
            }
            return listaDto;
        }
    }
}