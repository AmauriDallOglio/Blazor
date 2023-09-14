using AutoMapper;
using Blazor.Aplicacao.DTO;
using Blazor.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Aplicacao.Mapeamento
{
    public class MappingEntidade : Profile
    {
        public MappingEntidade()
        {
            CreateMap<Tenant, TenantDTO>();
        }

    }
}
