using Blazor.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Aplicacao.DTO
{
    public class AuditoriaDTO
    {
        public Guid Id { get; set; }
        public Guid Id_Tenant { get; set; }
        public string NomeTabela { get; set; }
        public string ModoCrud { get; set; }
        public DateTime DataCadastro { get; set; }
        public string HistoricoAntes { get; set; }
        public string HistoricoDepois { get; set; }

    }


    public class AudiotoriaApiOut : DetalheApi
    {
        public AuditoriaDTO Auditoria { get; set; }

        public AuditoriaDTO ConvertEntidadeEmDTO(Auditoria auditoria, int statusApi, string titleApi, string detailApi)
        {
            Auditoria = new AuditoriaDTO();
            Auditoria.Id = auditoria.Id;
            Auditoria.Id_Tenant = auditoria.Id_Tenant;
            Auditoria.NomeTabela = auditoria.NomeTabela;
            Auditoria.ModoCrud = auditoria.ModoCrud;
            Auditoria.DataCadastro = auditoria.DataCadastro;
            Auditoria.HistoricoAntes = auditoria.HistoricoAntes;
            Auditoria.HistoricoDepois = auditoria.HistoricoDepois;
 
            StatusApi = statusApi;
            TitleApi = titleApi;
            DetailApi = detailApi;

            return this.Auditoria;
        }
    }

    public class AuditoriaApiListaOut : DetalheApi
    {
        public virtual List<AuditoriaDTO> Auditorias { get; set; }
        public List<AuditoriaDTO> RetornaLista(List<AuditoriaDTO> lista, int statusApi, string titleApi, string detailApi)
        {
            Auditorias = lista;
            StatusApi = statusApi;
            TitleApi = titleApi;
            DetailApi = detailApi;
            return this.Auditorias;

        }

    }
}
