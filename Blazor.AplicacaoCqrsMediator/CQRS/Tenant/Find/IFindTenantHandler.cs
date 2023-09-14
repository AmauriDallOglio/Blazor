namespace Blazor.AplicacaoCqrsMediator.CQRS.Tenant.Find
{
    public interface IFindTenantHandler
    {

        FindTenantByIdResponse Handle(FindTenantByIdRequest command);

    }
}
