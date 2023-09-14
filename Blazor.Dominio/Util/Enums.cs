using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Serialization;

namespace Blazor.Dominio.Util
{
    public class Enums
    {
    }
    public enum SituacaoEnum
    {
        [Description("Ativo")]
        [Display(Name = "Ativo")]
        [EnumMember(Value = "Ativo")]
        Ativo = 0,
        [Description("Inativo")]
        [Display(Name = "Inativo")]
        [EnumMember(Value = "Inativo")]
        Inativo = 1,
    }

    public enum DiaDaSemana : short
    {
        //
        // Resumo:
        //     Domingo. Valor = DayOfWeek.Sunday.
        [Description("Domingo")]
        Domingo,
        //
        // Resumo:
        //     Segunda-feira. Valor = DayOfWeek.Monday.
        [Description("Segunda-feira")]
        SegundaFeira,
        //
        // Resumo:
        //     Terça-feira. Valor = DayOfWeek.Tuesday.
        [Description("Terça-feira")]
        TercaFeira,
        //
        // Resumo:
        //     Quarta-feira. Valor = DayOfWeek.Wednesday.
        [Description("Quarta-feira")]
        QuartaFeira,
        //
        // Resumo:
        //     Quinta-feira. Valor = DayOfWeek.Thursday.
        [Description("Quinta-feira")]
        QuintaFeira,
        //
        // Resumo:
        //     Sexta-feira. Valor = DayOfWeek.Friday.
        [Description("Sexta-feira")]
        SextaFeira,
        //
        // Resumo:
        //     Sábado. Valor = DayOfWeek.Saturday.
        [Description("Sábado")]
        Sabado
    }
    public enum TipoEventualidadeSituacao : short
    {

        [Description("Anotação")]
        Anotacao = 0,

        [Description("Gera repasse")]
        GeraRepasse = 1,

        [Description("Cancela repasse")]
        CancelaRepasse = 2
    }

    public enum EventualidadeSituacao : short
    {
        [Description("Não processado")]
        NaoProcessado = 0,

        [Description("Processado")]
        Processado = 1,

        [Description("Cancelado")]
        Cancelado = 2
    }

    public enum SimNao : short
    {
        [Description("Sim")]
        Sim = 1,

        [Description("Não")]
        Não = 0
    }

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

    public enum ModoCruds : short
    {
        [Description("Inserir")]
        Inserir = 1,

        [Description("Alterar")]
        Alterar = 2,

        [Description("Excluir")]
        Excluir = 3
    }
}
