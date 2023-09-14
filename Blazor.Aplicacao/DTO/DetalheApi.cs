using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Aplicacao.DTO
{
    public  class DetalheApi
    {
        public int StatusApi { get; set; }  //= 400, // Código de status HTTP para erro interno do servidor
        public string TitleApi { get; set; } //    Title = "Erro durante o processo de cadastrar do Tenant.",
        public string DetailApi { get; set; } // Detail = erro.Message

    }
}
