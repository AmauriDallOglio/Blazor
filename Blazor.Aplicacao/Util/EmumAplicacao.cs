using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Aplicacao.Util
{
    public class EmumAplicacao
    {
        public enum TipoHttp
        {
            [Description("(OK) para requisições bem-sucedidas")]
            [Display(Name = "(OK) para requisições bem-sucedidas")]
            [EnumMember(Value = "200")]
            Ok = 200,
            [Description("(Bad Request) para erros de validação de entrada")]
            [Display(Name = "(Bad Request) para erros de validação de entrada")]
            [EnumMember(Value = "400")]
            BadRequest = 400,
        }

        //public enum ModoCrud : short
        //{
        //    [Description("Inserir")]
        //    Inserir = 1,

        //    [Description("Alterar")]
        //    Alterar = 2,

        //    [Description("Excluir")]
        //    Excluir = 3
        //}

    }


    //[SwaggerResponse(statusCode: 401, Description = "(Unauthorized) para falhas de autenticação")]
    //[SwaggerResponse(statusCode: 403, Description = "(Access denied) Acesso negado")]
    //[SwaggerResponse(statusCode: 404, Description = "(Not Found) Página não encontrada")]
    //[SwaggerResponse(statusCode: 500, Description = "(Server error) erro no servidor")]


}
