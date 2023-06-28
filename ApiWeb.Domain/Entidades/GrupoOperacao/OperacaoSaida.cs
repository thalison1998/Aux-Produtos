using ApiWeb.Domain.EntidadeAbstract;
using ApiWeb.Domain.Enums;

namespace ApiWeb.Domain.Entidades.RegistroFinanceiro;
public class OperacaoSaida : Operacao
{
    public override decimal Valor { get; set; }
    public override EnumTipoFinanceiro TipoFinanceiro { get; set; }
    public override GrupoRegistroFinanceiro.RegistroFinanceiro RegistroFinanceiro { get; set; }
    public override Guid RegistroFinanceiroId { get; set; }

    public OperacaoSaida(decimal valor, Guid registroFinanceiroId)
    {
        Valor = valor;
        TipoFinanceiro = EnumTipoFinanceiro.Saida;
        RegistroFinanceiroId = registroFinanceiroId;
    }
}