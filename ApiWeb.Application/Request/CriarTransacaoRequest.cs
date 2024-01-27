using ApiWeb.Application.Request.Validation;
using ApiWeb.Domain.Enums;
using FluentValidation.Results;

namespace ApiWeb.Application.Request;

public class CriarTransacaoRequest
{
    private readonly CriarTransacaoRequestValidator _validator;

    public CriarTransacaoRequest()
    {
        _validator = new CriarTransacaoRequestValidator();
    }

    public decimal ValorTransacao { get; set; }
    public TipoTransacaoEnum TipoTransacao { get; set; }
    public string? DescricaoTransacao { get; set; }

    public bool EhValido() => Validar().IsValid;
    public ValidationResult Validar() => _validator.Validate(this);
}