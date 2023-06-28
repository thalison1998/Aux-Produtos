using ApiWeb.Domain.Enums;

namespace ApiWeb.Domain.EntidadeAbstract.Interfaces;

public interface IOperacaoCreate
{
    Operacao CriarOperacao(EnumTipoFinanceiro tipo, decimal valor, Guid financeiroId);
}