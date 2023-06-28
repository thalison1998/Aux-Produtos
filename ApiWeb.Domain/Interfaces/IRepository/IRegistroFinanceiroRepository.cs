using ApiWeb.Domain.Entidades.GrupoRegistroFinanceiro;

namespace ApiWeb.Domain.Interfaces.IRepository;

public interface IRegistroFinanceiroRepository : IBaseRepository<RegistroFinanceiro> 
{
    Task<RegistroFinanceiro?> ObterPorIdComOperacaoAsync(Guid registroFinanceiroId);
}
