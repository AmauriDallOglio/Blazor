using Blazor.Aplicacao.Aplicacao;
using Blazor.Aplicacao.DTO;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Blazor.Api.Controllers
{
    [Route("api/v1/Tenant")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        //private readonly ITenantRepositorio _iTenantRepositorio;
        private readonly TenantAplicacao _tenantAplicacao;
        //private readonly IAuditoriaAplicacao _iAuditoriaAplicacao;
        public TenantController(TenantAplicacao tenantAplicacao) //,  ITenantRepositorio iTenantRepositorio, IAuditoriaAplicacao iAuditoriaAplicacao)
        {
            //_iTenantRepositorio = iTenantRepositorio;
            _tenantAplicacao = tenantAplicacao;
            //_iAuditoriaAplicacao = iAuditoriaAplicacao;
        }



        //[HttpPost]
        //[Route("CreateMediator")]
        //public Task<CreateTenantMediatorResponse> CreateMediator([FromServices] IMediator mediator, [FromBody] CreateTenantMediatorRequest command)
        //{
        //    var response = mediator.Send(command);
        //    return response;
        //}


        ////[HttpGet]
        ////[Route("GetByIdMediator")]
        ////public IActionResult GetByIdCqrs([FromServices] IMediator mediator, [FromQuery] FindTenantByIdRequest command)
        ////{
        ////    var result = mediator.Send(command);
        ////    return Ok(result);
        ////}



        //[HttpPost]
        //[Route("CreateCqrs")]
        //public CreateTenantResponse CreateCqrs([FromServices] ICreateTenantHandler handler, [FromBody] CreateTenantRequest command)
        //{
        //    var response = handler.Handle(command);
        //    return response;
        //}

        //[HttpGet]
        //[Route("GetByIdCqrs")]
        //public IActionResult GetByIdCqrs([FromServices] IFindTenantHandler handler, [FromQuery] FindTenantByIdRequest command)
        //{
        //    var result = handler.Handle(command);
        //    return Ok(result);
        //}



        [SwaggerResponse(statusCode: 201, Description = "Retorno com sucesso", StatusCode = 200,  Type = typeof(TenantApiOut))]
        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid id)
        {
            TenantApiOut resultado = _tenantAplicacao.ObterPorId(id);
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        [SwaggerResponse(statusCode: 201, Description = "Retorno com sucesso", StatusCode = 200, Type = typeof(TenantApiListaOut))]
        [HttpGet("Todos")]
        public IActionResult ObterTodos()
        {
            var lista = _tenantAplicacao.ListarTodos();
            if (lista == null)
            {
                return NotFound();
            }
            return Ok(lista);
        }

        [SwaggerResponse(statusCode: 201, Description = "Retorno com sucesso", Type = typeof(TenantApiOut))]
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(TenantApiIncluir apiIn)
        {
            try
            {
                TenantApiOut resultado = _tenantAplicacao.Incluir(apiIn);
                if ( resultado.StatusApi >= 400)
                {
                    var problemDetails = new ProblemDetails
                    {
                        Status = resultado.StatusApi,
                        Title = resultado.TitleApi,
                        Detail = resultado.DetailApi,
                    };
                    return StatusCode(problemDetails.Status.Value, problemDetails);
                }
                return  CreatedAtAction(nameof(ObterPorId), new { id = resultado.Tenant.Id }, resultado);
            }
            catch (Exception erro)
            {
                string innerExceptionMessage = erro.InnerException == null ? "" : erro.InnerException.Message;
                var problemDetails = new ProblemDetails
                {
                    Status = 500, 
                    Title = "(Internal Server) Ocorreu uma falha na plataforma. Por favor, entre em contato com o atendimento.",
                    Detail = "Detalhe: " + erro.Message + " / InnerException:" + innerExceptionMessage    // + " / StackTrace: " + erro.StackTrace
                };
                return StatusCode(problemDetails.Status.Value, problemDetails);
            }
        }

        



    }
}
