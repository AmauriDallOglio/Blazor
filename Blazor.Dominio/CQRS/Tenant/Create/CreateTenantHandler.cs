using Blazor.Dominio.InterfaceRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Dominio.Commands.Tenant.Create
{
    public class CreateTenantHandler : ICreateTenantHandler
    {

        ITenantRepositorio _iTenantRepositorio;

        public CreateTenantHandler(ITenantRepositorio repository)
        {
            _iTenantRepositorio = repository;
        }

        public CreateTenantResponse Handle(CreateTenantRequest request)
        {
            var tenant = _iTenantRepositorio.BuscarTodos().FirstOrDefault();
            var result = new CreateTenantResponse
            {
                Id = tenant.Id, //Guid.NewGuid(),  
                Name = tenant.Descricao, // "Amauri",  
                Email = "Amauri@gmail.com", 
                Date = DateTime.Now
            };
            return result;
        }
    }
}
