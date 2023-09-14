using Blazor.Dominio.Entidade;
using Blazor.Dominio.Modelo;
using FluentValidation;

namespace Blazor.Dominio.Validador
{
    public class TenantValidador : AbstractValidator<Tenant>
    {
        public TenantValidador()
        {
            RuleFor(x => x.Referencia).NotEmpty().WithMessage("O valor de Referencia é inválido");
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("O valor de Descricao é inválido");

        }

        public ResultadoOperacao<Tenant> Validar(Tenant entidade)
        {
            var resultado = new ResultadoOperacao<Tenant>(null);
            var validacao = Validate(entidade);
            if (!validacao.IsValid)
                validacao.Errors.Each(e =>
                {
                    resultado.Sucesso = false;
                    resultado.Mensagem += e.ErrorMessage + " " + e.PropertyName + " " + e.ErrorCode + " ";
                });
            return resultado;
        }


    }
}
