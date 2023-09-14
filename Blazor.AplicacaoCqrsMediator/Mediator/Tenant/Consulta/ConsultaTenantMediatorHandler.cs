using AutoMapper;
using Blazor.Dominio.InterfaceRepositorio;
using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Consulta
{
    public class ConsultaTenantMediatorHandler : IRequestHandler<ConsultaTenantMediatorRequest, ConsultaTenantMediatorResponse>
    {
        private readonly ITenantRepositorio _iTenantRepositorio;
        private readonly IMapper _mapper;

        public ConsultaTenantMediatorHandler(ITenantRepositorio repository, IMapper mapper)
        {
            _iTenantRepositorio = repository;
            _mapper = mapper;
        }

        public async Task<ConsultaTenantMediatorResponse> Handle(ConsultaTenantMediatorRequest request, CancellationToken cancellationToken)
        {
            Dominio.Entidade.Tenant tenant = _iTenantRepositorio.BuscarPorId(request.Id);
            var resultado = _mapper.Map<ConsultaTenantMediatorResponse>(tenant);
            return await Task.FromResult(resultado);
        }

        //public async Task<ConsultaTenantMediatorResponse> Handle(ConsultaTenantMediatorRequest request, CancellationToken cancellationToken)
        //{
        //    Entidade.Tenant tenant = _iTenantRepositorio.BuscarPorId(request.Id);
        //    var resultado = _mapper.Map<ConsultaTenantMediatorResponse>(tenant);
        //    //var resultado = new FindTenantMediatorResponse
        //    //{
        //    //    Id = tenant.Id, //Guid.NewGuid(),  
        //    //    Descricao = tenant.Descricao, // "Amauri",
        //    //    Id_Imagem = tenant.Id_Imagem,
        //    //    Referencia = tenant.Referencia,
        //    //    Inativo = tenant.Inativo
        //    //};
        //    return await Task.FromResult(resultado);
        //}


    }
}
