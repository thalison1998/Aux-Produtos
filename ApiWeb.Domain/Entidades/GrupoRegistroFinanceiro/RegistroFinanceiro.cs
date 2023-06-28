using ApiWeb.Domain.EntidadeAbstract;

namespace ApiWeb.Domain.Entidades.GrupoRegistroFinanceiro;

public class RegistroFinanceiro : Base
{
    public RegistroFinanceiro(string? descricao)
    {
        Descricao = descricao;
    }

    public string? Descricao { get; private set; }
    public decimal ValorTotal { get; private set; }
    public virtual List<Operacao>? Operacoes { get; private set; } = new List<Operacao>();

    public void AdicionarOperacao(Operacao operacoes)
    {
        Operacoes?.Add(operacoes);
    }

    public void AtualizarValorPositivo(decimal valor)
    {
        ValorTotal += valor;
    }

    public void AtualizarValorNegativo(decimal valor)
    {
        ValorTotal -= valor;
    }
}
