using ApiWeb.Domain.Domains;

namespace ApiWeb.Domain.Service.Interface;

public interface IRegistroFinanceiroService
{
    Task<RegistroFinanceiro> Criar(RegistroFinanceiro registroFinanceiro);
    Task<RegistroFinanceiro> ExisteRegistroFinanceiroAnoMesAtual();
    //Task<List<RegistroFinanceiro>> ListarTodosRegistrosFinanceiros();
}