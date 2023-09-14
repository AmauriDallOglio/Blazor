using AutoMapper;
using Blazor.Dominio.InterfaceRepositorio;
using Blazor.Dominio.Modelo;
using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Consulta
{
    public class ConsultaTenantListaTodosHandler : IRequestHandler<ConsultaTenantListaTodosRequest, RetornoPaginadoGenerico<ConsultaTenantListaTodosResponse>>
    {
        private readonly ITenantRepositorio _iTenantRepositorio;
        private readonly IMapper _mapper;

        public ConsultaTenantListaTodosHandler(ITenantRepositorio repository, IMapper mapper)
        {
            _iTenantRepositorio = repository;
            _mapper = mapper;
        }

        public async Task<RetornoPaginadoGenerico<ConsultaTenantListaTodosResponse>> Handle(ConsultaTenantListaTodosRequest request, CancellationToken cancellationToken) //Task<IEnumerable<ConsultaTenantListaTodosResponse>> Handle(ConsultaTenantListaTodosRequest request, CancellationToken cancellationToken)
        {
            var listaTenant = _iTenantRepositorio.BuscarTodosPorDescricao(request.Descricao);
            //if 
            var listaDto = _mapper.Map<List<ConsultaTenantListaTodosResponse>>(listaTenant);
            //var primeiro = listaDto.FirstOrDefault();
            //ConsultaTenantListaTodosResponse retorno = _mapper.Map<ConsultaTenantListaTodosResponse>(primeiro);
            RetornoPaginadoGenerico < ConsultaTenantListaTodosResponse > retornoPaginado = new RetornoPaginadoGenerico<ConsultaTenantListaTodosResponse>
            {
                Modelos = listaDto,
                ItemPorPagina = 1,
                Pagina = 10,
                TotalRegistros = listaDto.Count()
            };

            return await Task.FromResult(retornoPaginado);
        }
    }
}

 