using MediatR;

namespace Blazor.AplicacaoCqrsMediator.Mediator.Auditoria.Inserir
{
    public class InserirAuditoriaRequest : IRequest<InserirAuditoriaResponse>
    {
        public Guid IdTenant { get; set; }
        public Guid IdRegistro { get; set; }
        public string NomeTabela { get; set; }

        public int ModoCrud { get; set; }
    }
}
