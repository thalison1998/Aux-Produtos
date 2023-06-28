using ApiWeb.Domain.Enums;

namespace ApiWeb.Application.Request;

public class CriarOperacaoRequest
{
    public decimal Valor { get; set; }
    public Guid RegistroFinanceiroId { get; set; }
    public EnumTipoFinanceiro TipoFinanceiro { get; set; }
}
