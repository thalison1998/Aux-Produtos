using FluentValidation;

namespace ApiWeb.Application.Request.Validation;

public class CriarTransacaoRequestValidator : AbstractValidator<CriarTransacaoRequest>
{
    public CriarTransacaoRequestValidator()
    {
        RuleFor(x => x.ValorTransacao).Must(valor => valor >= 0).WithMessage("Valor não pode ser negativo.");
    }
}