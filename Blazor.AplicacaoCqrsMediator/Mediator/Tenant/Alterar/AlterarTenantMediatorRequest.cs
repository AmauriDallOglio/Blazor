using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Alterar
{
    public class AlterarTenantMediatorRequest : IRequest<AlterarTenantMediatorResponse>
    {
        public Guid Id { get; set; }
        public Guid? Id_Imagem { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Inativo { get; set; }
    }
}
