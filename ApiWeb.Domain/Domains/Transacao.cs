using ApiWeb.Domain.Enums;

namespace ApiWeb.Domain.Domains;

public class Transacao : Base
{
    public Transacao() { }

    public Transacao(decimal valorTransacao, string descricaoTransacao, Guid registroFinanceiroId, TipoTransacaoEnum tipoTransacaoEnum)
    {
        ValorTransacao = valorTransacao;
        RegistroFinanceiroId = registroFinanceiroId;
        TipoTransacaoEnum = tipoTransacaoEnum;
        DescricaoTransacao = descricaoTransacao;
    }

    public decimal ValorTransacao { get; private set; }
    public string DescricaoTransacao { get; private set; }
    public RegistroFinanceiro RegistroFinanceiro { get; private set; }
    public Guid RegistroFinanceiroId { get; private set; }
    public TipoTransacaoEnum TipoTransacaoEnum { get; private set; }
}