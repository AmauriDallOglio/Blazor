using Blazor.Dominio.InterfaceRepositorio;

namespace Blazor.AplicacaoCqrsMediator.CQRS.Tenant.Create
{
    public class CreateTenantHandler : ICreateTenantHandler
    {

        ITenantRepositorio _iTenantRepositorio;

        public CreateTenantHandler(ITenantRepositorio repository)
        {
            _iTenantRepositorio = repository;
        }

        public CreateTenantResponse Handle(CreateTenantRequest request)
        {

            //var result = new CreateTenantResponse
            //{
            //    Id = Guid.NewGuid(),
            //    Referencia = request.Referencia,
            //    Descricao = request.Descricao,
            //    Id_Imagem = null,
            //    Inativo = false,
            //    Email = "Amauri@gmail.com",
            //    Date = DateTime.Now
            //};
            //var tenant = _iTenantRepositorio.Incluir(result);

            var result = new CreateTenantResponse
            {
                Id = Guid.NewGuid(),
                Referencia = request.Referencia,
                Descricao = request.Descricao,
                Id_Imagem = null,
                Inativo = false,
                Email = "Amauri@gmail.com",
                Date = DateTime.Now
            };
            return result;
        }
    }
}
