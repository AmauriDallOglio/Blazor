 
using Blazor.Dominio.Entidade;
using Blazor.Dominio.InterfaceRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    public class TenantsController : Controller
    {
        private readonly ILogger<Tenant> _logger;
        private readonly ITenantRepositorio _iTenantRepositorio;
 
        public TenantsController(ILogger<Tenant> logger, ITenantRepositorio iTenantRepositorio)
        {
            _logger = logger;
            _iTenantRepositorio = iTenantRepositorio;
         
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [Route("api/Tenants/RetornaTodos")]
        public IEnumerable<Tenant> RetornaTodos()
        {
            //return Enumerable.Range(1, 5).Select(index => new Empresa
            //{
            //    Descricao = "aaaaaa"
            //}).ToArray();


            var resultado = _iTenantRepositorio.BuscarTodos();
            return resultado;
        }


        [HttpPost]
        [Route("api/Tenants/Incluir")]
        public async void Incluir(Tenant empresa)
        {
            empresa.Descricao = "Inserido em: " + DateTime.Now.ToString();
            var resultado = _iTenantRepositorio.Incluir(empresa);

        }



    }
}
