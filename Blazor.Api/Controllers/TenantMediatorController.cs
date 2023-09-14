using Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Alterar;
using Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Consulta;
using Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Excluir;
using Blazor.AplicacaoCqrsMediator.Mediator.Tenant.Inserir;
using Blazor.Dominio.Modelo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Api.Controllers
{
    [Route("api/v1/TenantMediator")]
    [ApiController]
    public class TenantMediatorController : ControllerBase
    {

        [HttpGet]
        //[Route("ListarTodosPelaDescricao")]
        [HttpPost("ListarTodos"), ActionName("ListarTodos")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        public async Task<RetornoPaginadoGenerico<ConsultaTenantListaTodosResponse>> ListarTodos([FromServices] IMediator mediator, [FromQuery] ConsultaTenantListaTodosRequest dadosEntrada) //fromHead
        {
            Task<RetornoPaginadoGenerico<ConsultaTenantListaTodosResponse>> response = mediator.Send(dadosEntrada);
            //Task<List<ConsultaTenantListaTodosResponse>> response = mediator.Send(dadosEntrada);
            return await response;
        }

        [HttpGet]
        [Route("ConsultarPorId")]
        public async Task<IActionResult> ConsultarPorId([FromServices] IMediator mediator, [FromQuery] ConsultaTenantMediatorRequest dadosEntrada)
        {
            Task<ConsultaTenantMediatorResponse> response = mediator.Send(dadosEntrada);
            return Ok(await response);
        }

        //[HttpPost]
        //[Route("Inserir")]
        [HttpPost("Inserir"), ActionName("Inserir")]
        [ProducesResponseType(200), ProducesResponseType(400), ProducesResponseType(500)]
        //Task<ResultadoOperacao<InserirTenantMediatorResponse>>
        public async Task<IActionResult> Inserir([FromServices] IMediator mediator, [FromBody] InserirTenantMediatorRequest dadosEntrada)
        {
            //ResultadoOperacao<InserirTenantMediatorResponse> resultadoOperacao = new ResultadoOperacao<InserirTenantMediatorResponse>(null);
            try
            {
                var response = mediator.Send(dadosEntrada);
                if (response.Result.Sucesso == false)
                {
                    return BadRequest(response.Result.Mensagem);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
   
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("Alterar")]
        public Task<AlterarTenantMediatorResponse> Alterar([FromServices] IMediator mediator, [FromBody] AlterarTenantMediatorRequest dadosEntrada)
        {
            var response = mediator.Send(dadosEntrada);
            return response;
        }

        [HttpDelete]
        [Route("Deletar")]
        public Task<ExcluirTenantMediatorResponse> Deletar([FromServices] IMediator mediator, [FromBody] ExcluirTenantMediatorRequest dadosEntrada)
        {
            var response = mediator.Send(dadosEntrada);
            return response;
        }
    }
}
