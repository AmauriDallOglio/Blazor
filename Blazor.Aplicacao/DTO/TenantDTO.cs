using Blazor.Dominio.Entidade;

namespace Blazor.Aplicacao.DTO
{
    public class TenantDTO  
    {
  

        public Guid Id { get; set; }
        public Guid? Id_Imagem { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Inativo { get; set; }
    }

    public class TenantApiIncluir
    {
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

    public class TenantApiAlterar
    {
        public Guid Id { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Inativo { get; set; }
    }

    public class TenantApiExcluir
    {
        public Guid Id { get; set; }
    }


    public class TenantApiOut : DetalheApi
    {
        public TenantDTO Tenant { get; set; }

        public TenantDTO ConvertEntidadeEmDTO(Tenant tenant, int statusApi, string titleApi, string detailApi)
        {
            Tenant = new TenantDTO();
            Tenant.Id = tenant.Id;
            Tenant.Id_Imagem = tenant.Id_Imagem;
            Tenant.Referencia = tenant.Referencia;
            Tenant.Descricao = tenant.Descricao;
            Tenant.Inativo = tenant.Inativo;

            StatusApi = statusApi;
            TitleApi = titleApi;
            DetailApi = detailApi;

            return this.Tenant;

        }
    }


    public class TenantApiListaOut : DetalheApi
    {
        public virtual List<TenantDTO> Tenants { get; set; }
        public List<TenantDTO> RetornaLista(List<TenantDTO> lista, int statusApi, string titleApi, string detailApi)
        {
            Tenants = lista;
            StatusApi = statusApi;
            TitleApi = titleApi;
            DetailApi = detailApi;
            return this.Tenants;

        }

    }

}
