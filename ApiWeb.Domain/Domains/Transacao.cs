using ApiWeb.Domain.Enums;

namespace ApiWeb.Domain.Domains;

public class Transacao : Base
{
    public Transacao() { }

    public Transacao(decimal valorTransacao, string descricaoTransacao, Guid registroFinanceiroId, TipoTransacaoEnum tipoTransacao)
    {
        if (valorTransacao < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(valorTransacao), "O valor da transação não pode ser menor que 0.");
        }

        ValorTransacao = valorTransacao;
        RegistroFinanceiroId = registroFinanceiroId;
        TipoTransacao = tipoTransacao;
        DescricaoTransacao = descricaoTransacao;
    }

    public decimal ValorTransacao { get; private set; }
    public string DescricaoTransacao { get; private set; }
    public RegistroFinanceiro RegistroFinanceiro { get; private set; }
    public Guid RegistroFinanceiroId { get; private set; }
    public TipoTransacaoEnum TipoTransacao { get; private set; }
}