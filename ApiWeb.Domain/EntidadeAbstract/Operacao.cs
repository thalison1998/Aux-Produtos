using ApiWeb.Domain.EntidadeAbstract.Interfaces;
using ApiWeb.Domain.Entidades;
using ApiWeb.Domain.Entidades.GrupoRegistroFinanceiro;
using ApiWeb.Domain.Enums;

namespace ApiWeb.Domain.EntidadeAbstract;

public abstract class Operacao : Base, IOperacao
{
    public abstract decimal Valor { get; set; }
    public abstract EnumTipoFinanceiro TipoFinanceiro { get; set; }
    public abstract RegistroFinanceiro RegistroFinanceiro { get; set; }
    public abstract Guid RegistroFinanceiroId { get; set; }
}