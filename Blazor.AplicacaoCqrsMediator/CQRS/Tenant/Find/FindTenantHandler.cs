﻿
using Blazor.Dominio.InterfaceRepositorio;

namespace Blazor.AplicacaoCqrsMediator.CQRS.Tenant.Find
{
    public class FindTenantHandler : IFindTenantHandler
    {

        ITenantRepositorio _iTenantRepositorio;

        public FindTenantHandler(ITenantRepositorio repository)
        {
            _iTenantRepositorio = repository;
        }

        public FindTenantByIdResponse Handle(FindTenantByIdRequest command)
        {
            var tenant = _iTenantRepositorio.BuscarPorId(command.Id);
            var result = new FindTenantByIdResponse
            {
                Id = tenant.Id, //Guid.NewGuid(),  
                Descricao = tenant.Descricao, // "Amauri",
                Id_Imagem = tenant.Id_Imagem, 
                Referencia = tenant.Referencia,
                Inativo = tenant.Inativo
            };
            return result;
        }
    }
}
