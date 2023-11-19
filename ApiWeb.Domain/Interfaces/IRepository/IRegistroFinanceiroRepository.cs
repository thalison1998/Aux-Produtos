using ApiWeb.Domain.Domains;

namespace ApiWeb.Domain.Interfaces.IRepository;

public interface IRegistroFinanceiroRepository : IBaseRepository<RegistroFinanceiro> 
{
    Task<RegistroFinanceiro> ExisteRegistroFinanceiroAnoMesAtual();
}