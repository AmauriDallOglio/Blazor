using AutoMapper;
using Blazor.Aplicacao.DTO;
using Blazor.Aplicacao.Interface;
using Blazor.Dominio.Entidade;
using Blazor.Dominio.InterfaceServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Aplicacao.Servicos
{
    //public class ServicoAppBase<TEntidade, TEntidadeDTO> : IAppBase<TEntidade, TEntidadeDTO>
    //    where TEntidade : EntidadeBase
    //    where TEntidadeDTO : DtoBase
    //{

    //    protected readonly IServicoBase<TEntidade> servico;
    //    protected readonly IMapper iMapper;
    //    private ITenantServico servico1;

    //    public ServicoAppBase(IMapper iMapper, ITenantServico servico1)
    //    {
    //        this.iMapper = iMapper;
    //        this.servico1 = servico1;
    //    }

    //    public TEntidadeDTO SelecionarPorId(int id)
    //    {
    //        return iMapper.Map<TEntidadeDTO>(servico.SelecionarPorId(id));
    //    }
    //}
}
