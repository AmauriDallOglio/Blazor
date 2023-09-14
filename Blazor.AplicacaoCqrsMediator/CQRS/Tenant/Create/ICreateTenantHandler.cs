namespace Blazor.AplicacaoCqrsMediator.CQRS.Tenant.Create
{
    public interface ICreateTenantHandler
    {
        CreateTenantResponse Handle(CreateTenantRequest request);
    }
}
