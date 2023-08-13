using Blazor.Aplicacao.Aplicacao;
using Blazor.Aplicacao.DTO;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Blazor.Api.Controllers
{
    public class AuditoriaController : Controller
    {
        private readonly AuditoriaAplicacao _AuditoriaAplicacao;
        public AuditoriaController(AuditoriaAplicacao auditoriaAplicacao)
        {
            _AuditoriaAplicacao = auditoriaAplicacao;
        }

        [SwaggerResponse(statusCode: 201, Description = "Retorno com sucesso", StatusCode = 200, Type = typeof(AuditoriaApiListaOut))]
        [HttpGet("Todos")]
        public IActionResult ObterTodos()
        {
            var lista = _AuditoriaAplicacao.ListarTodos();
            if (lista == null)
            {
                return NotFound();
            }
            return Ok(lista);
        }
    }
}
