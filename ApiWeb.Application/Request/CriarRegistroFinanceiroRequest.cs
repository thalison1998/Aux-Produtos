namespace ApiWeb.Application.Request;

public class CriarRegistroFinanceiroRequest
{
    public string? Descricao { get; set; }
    public List<CriarOperacaoRequest>? Operacoes { get; set; }
}