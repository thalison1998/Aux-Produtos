using ApiWeb.Domain.Domains;
using ApiWeb.Domain.Enums;

namespace ApiWeb.Application.Response;

public class TransacaoResponse
{
    public decimal ValorTransacao { get; set; }
    public RegistroFinanceiro RegistroFinanceiro { get; set; }
    public Guid RegistroFinanceiroId { get; set; }
    public TipoTransacaoEnum TipoTransacaoEnum { get; set; }
}