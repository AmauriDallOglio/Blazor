using Blazor.AplicacaoCqrsMediator.CQRS.Tenant.Create;
using Blazor.AplicacaoCqrsMediator.CQRS.Tenant.Find;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Api.Controllers
{
    [Route("api/v1/TenantCQRS")]
    [ApiController]
    public class TenantCQRSController : ControllerBase
    {
 

        [HttpPost]
        [Route("CreateCqrs")]
        public CreateTenantResponse CreateCqrs([FromServices] ICreateTenantHandler handler, [FromBody] CreateTenantRequest command)
        {
            var response = handler.Handle(command);
            return response;
        }

        [HttpGet]
        [Route("GetByIdCqrs")]
        public IActionResult GetByIdCqrs([FromServices] IFindTenantHandler handler, [FromQuery] FindTenantByIdRequest command)
        {
            var result = handler.Handle(command);
            return Ok(result);
        }
 
    }
}
