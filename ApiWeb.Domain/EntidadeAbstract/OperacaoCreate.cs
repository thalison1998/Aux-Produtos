using ApiWeb.Domain.EntidadeAbstract.Interfaces;
using ApiWeb.Domain.Entidades.RegistroFinanceiro;
using ApiWeb.Domain.Enums;

namespace ApiWeb.Domain.EntidadeAbstract;
public class OperacaoCreate: IOperacaoCreate
{
    public Operacao CriarOperacao(EnumTipoFinanceiro tipo, decimal valor, Guid financeiroId)
    {
        switch (tipo)
        {
            case EnumTipoFinanceiro.Entrada:
                return new OperacaoEntrada(valor, financeiroId);
            case EnumTipoFinanceiro.Saida:
                return new OperacaoSaida(valor, financeiroId);
            default:
                throw new ArgumentException("Tipo de registro de operação inválido.");
        }
    }
}