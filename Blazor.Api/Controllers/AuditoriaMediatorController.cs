using Blazor.AplicacaoCqrsMediator.Mediator.Auditoria.Inserir;
using Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Inserir;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Api.Controllers
{
    [Route("api/v1/AuditoriaMediator")]
    [ApiController]
    public class AuditoriaMediatorController : ControllerBase
    {

        [HttpPost]
        [Route("Inserir")]
        public Task<InserirAuditoriaResponse> Inserir([FromServices] IMediator mediator, [FromBody] InserirAuditoriaRequest dadosEntrada)
        {
            var response = mediator.Send(dadosEntrada);
            return response;
        }
    }
}
