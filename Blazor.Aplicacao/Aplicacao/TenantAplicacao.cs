using Blazor.Aplicacao.DTO;
using Blazor.Aplicacao.Interface;
using Blazor.Dominio.Entidade;
using Blazor.Dominio.InterfaceRepositorio;

namespace Blazor.Aplicacao.Aplicacao
{
    public class TenantAplicacao : ITenantAplicacao
    {
        private readonly ITenantRepositorio _iTenantRepositorio;
        public TenantAplicacao(ITenantRepositorio iTenantRepositorio)
        {
            _iTenantRepositorio = iTenantRepositorio;
        }

        public TenantApiOut ObterPorId(Guid id)
        {
            var tenant = _iTenantRepositorio.BuscarPorId(id);
            TenantApiOut retornoDto = new TenantApiOut();
            retornoDto.ConvertEntidadeEmDTO(tenant, 201, "(GET) Obtido com sucesso", "Obtido com sucesso");
            return retornoDto;
        }

        public TenantApiListaOut ListarTodos()
        {
            List<TenantDTO> listaTenantDto = new List<TenantDTO>();
            listaTenantDto = ConvertEntidadeEmDTO(listaTenantDto);
            TenantApiListaOut listaRetornoApi = new TenantApiListaOut();
            listaRetornoApi.RetornaLista(listaTenantDto, 201, "(GET) Listado com sucesso", "Listado com sucesso");
            return listaRetornoApi;
        }

        public List<TenantDTO> ConvertEntidadeEmDTO(List<TenantDTO> listaDto)
        {
            TenantApiOut retornoDto = new TenantApiOut();
            var listaRepositorio = _iTenantRepositorio.BuscarTodos();
            foreach (Tenant item in listaRepositorio)
            {
                retornoDto.ConvertEntidadeEmDTO(item, 0, "", "");
                listaDto.Add(retornoDto.Tenant);
            }
            return listaDto;
        }

        public TenantApiOut Incluir(TenantApiIncluir apiIn)
        {
            TenantApiOut retornoDto = new TenantApiOut();
            Tenant tenant = new Tenant();
            //tenant = tenant.GerandoDadosNoIncluir(apiIn.Referencia, apiIn.Descricao);
            //var validacao = tenant.Validacoes(tenant);
            //if (!string.IsNullOrEmpty(validacao) || !string.IsNullOrWhiteSpace(validacao))
            //{
            //    retornoDto.ConvertEntidadeEmDTO(tenant, 400, "(Bad Request) Erro de validação de entrada", validacao);
            //    return retornoDto;
            //}
            //tenant = _iTenantRepositorio.Incluir(tenant);
            retornoDto.ConvertEntidadeEmDTO(tenant, 201, "(Created) Criado com sucesso", "Incluido com sucesso");
            return retornoDto;
        }

 
    }
}
