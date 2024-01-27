using ApiWeb.Domain.Domains;

namespace ApiWeb.Application.Response;

public class RegistroFinanceiroResponse
{
    public decimal ValorTotal { get; set; }
    public List<TransacaoResponse> Transacoes { get; set; }
}