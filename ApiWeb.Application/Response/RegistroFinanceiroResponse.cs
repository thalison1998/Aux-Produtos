using ApiWeb.Domain.EntidadeAbstract;

namespace ApiWeb.Application.Response;

public class RegistroFinanceiroResponse
{
    public Guid Id { get; set; }
    public string? Descricao { get; set; }
    public decimal ValorTotal { get; set; }
    public List<OperacaoResponse>? Operacoes { get; set; }
}
