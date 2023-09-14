using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Auditoria.Excluir
{
    public class ExcluirAuditoriaRequest : IRequest<ExcluirAuditoriaResponse>
    {
        public Guid IdTenant { get; set; }
        public Guid IdRegistro { get; set; }
        public string NomeTabela { get; set; }
    }
}
