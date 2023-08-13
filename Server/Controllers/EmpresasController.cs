 using Blazor.Dominio.Entidade;
using Blazor.Dominio.InterfaceRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    public class EmpresasController : Controller
    {

        private readonly ILogger<Tenant> _logger;
        private readonly ITenantRepositorio _iEmpresaRepositorio;
        public EmpresasController(ILogger<Tenant> logger, ITenantRepositorio iEmpresaRepositorio)
        {
            _logger = logger;
            _iEmpresaRepositorio = iEmpresaRepositorio;
        }

        [HttpGet]
        [Route("api/Empresas/RetornaTodos")]
        public IEnumerable<Tenant> RetornaTodos()
        {
            //return Enumerable.Range(1, 5).Select(index => new Empresa
            //{
            //    Descricao = "aaaaaa"
            //}).ToArray();


            var resultado = _iEmpresaRepositorio.BuscarTodos();
            return resultado;
        }




        [HttpPost]
        [Route("api/Empresas/Incluir")]
        public async void Incluir(Tenant empresa)
        {
            empresa.Descricao = "Inserido em: " + DateTime.Now.ToString();
            var resultado = _iEmpresaRepositorio.Incluir(empresa);

        }


    }
}
