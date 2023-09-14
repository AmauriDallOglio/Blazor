using Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Inserir;
using Blazor.Dominio.Modelo;
using Blazor.Dominio.Entidade;
using Blazor.Dominio.Validador;
using System.ComponentModel.DataAnnotations;


namespace Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Interface
{
    public interface ITenantMediatorInserir
    {
        // private async Task InserirAuditoria(Guid idTenante, Guid idRegistroAtual);
 
        public Task InserirAuditoria(Guid idTenante, Guid idRegistroAtual);

        public ResultadoOperacao<InserirTenantMediatorResponse> CriarResultadoOperacao();

        ResultadoOperacao<Dominio.Entidade.Tenant> ValidaMapeamento(Dominio.Entidade.Tenant entidade);

    }
}
