using ApiWeb.Domain.Entidades.GrupoRegistroFinanceiro;
using ApiWeb.Domain.Enums;

namespace ApiWeb.Domain.EntidadeAbstract.Interfaces;

public interface IOperacao
{
    decimal Valor { get; set; }
    EnumTipoFinanceiro TipoFinanceiro { get; set; }
    RegistroFinanceiro RegistroFinanceiro { get; set; }
    Guid RegistroFinanceiroId { get; set; }
}