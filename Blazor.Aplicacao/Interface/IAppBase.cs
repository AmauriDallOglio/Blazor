using Blazor.Aplicacao.DTO;
using Blazor.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Aplicacao.Interface
{
    public interface IAppBase<TEntidade, TEntidadeDTO> 
            where TEntidade : EntidadeBase
            where TEntidadeDTO : DtoBase
    {
        //int Incluir(TEntidadeDTO entidade);
        //void Excluir(int id);
        //void Excluir(TEntidadeDTO entidade);
        //void Alterar(TEntidadeDTO entidade);
        TEntidadeDTO SelecionarPorId(int id);
        //IEnumerable<TEntidadeDTO> SelecionarTodos();
    }
}
