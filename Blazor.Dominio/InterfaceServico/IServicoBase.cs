﻿using Blazor.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Dominio.InterfaceServico
{
    public interface IServicoBase<TEntidade>
         where TEntidade : EntidadeBase
    {
        //int Incluir(TEntidade entidade);
        //void Excluir(int id);
        //void Excluir(TEntidade entidade);
        //void Alterar(TEntidade entidade);
        TEntidade SelecionarPorId(int id);
        //IEnumerable<TEntidade> SelecionarTodos();
    }
}
