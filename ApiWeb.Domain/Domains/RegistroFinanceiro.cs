using ApiWeb.Domain.Enums;

namespace ApiWeb.Domain.Domains;
public class RegistroFinanceiro : Base
{
    public RegistroFinanceiro() { }

    public RegistroFinanceiro(decimal valorTotal)
    {
        ValorTotal = valorTotal;
    }

    public decimal ValorTotal { get; private set; }
    public virtual List<Transacao> Transacao { get; private set; } = new();


    public Transacao AdicionarTransacao(Transacao transacao)
    {
        transacao.LimparId();

        Transacao.Add(transacao);

        AtualizacaoValorTotal(transacao);

        return transacao;
    }

    private void AtualizacaoValorTotal(Transacao transacao) 
    { 
        if(transacao.TipoTransacaoEnum == TipoTransacaoEnum.Entrada)
        {
            ValorTotal += transacao.ValorTransacao;
        }
        else
        {
            ValorTotal -= transacao.ValorTransacao;
        }
    }
}