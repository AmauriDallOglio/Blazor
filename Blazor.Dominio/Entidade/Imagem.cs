using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Dominio.Entidade
{
    public class Imagem
    {
        public string Id { get; set; }
        public Guid Id_Tenant { get; set; }
        public Tenant Tenant { get; set; }

        public string Referencia { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
    }
}
