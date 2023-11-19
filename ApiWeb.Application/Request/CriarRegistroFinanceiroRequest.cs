using ApiWeb.Application.Request.Validation;
using FluentValidation.Results;

namespace ApiWeb.Application.Request;

public class CriarRegistroFinanceiroRequest
{
    private readonly CriarRegistroFinanceiroRequestValidator _validator;
    public CriarRegistroFinanceiroRequest()
    {
        _validator = new CriarRegistroFinanceiroRequestValidator();
    }

    public decimal ValorTotal { get; set; }
    public List<CriarTransacaoRequest> Transacoes { get; set; }

    public bool EhValido() => Validar().IsValid;
    public ValidationResult Validar() => _validator.Validate(this);
}