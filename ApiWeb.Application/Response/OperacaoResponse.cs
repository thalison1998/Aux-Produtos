using ApiWeb.Domain.Enums;

namespace ApiWeb.Application.Response;

public class OperacaoResponse
{
    public Guid Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataCriacao { get; set; }
    public EnumTipoFinanceiro TipoFinanceiro { get; set; }
}

