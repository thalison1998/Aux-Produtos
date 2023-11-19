using ApiWeb.Domain.Domains;
using ApiWeb.Domain.Interfaces.IRepository;
using ApiWeb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Infra.Data.Repository;

public class RegistroFinanceiroRepository : BaseRepository<RegistroFinanceiro>, IRegistroFinanceiroRepository
{
    public RegistroFinanceiroRepository(WebApiDbContext context) : base(context) { }

    public async Task<RegistroFinanceiro> ExisteRegistroFinanceiroAnoMesAtual()
    {
        DateTime dataAtual = DateTime.Now;
        int mesAtual = dataAtual.Month;
        int anoAtual = dataAtual.Year;

        return await Obter()
            .FirstOrDefaultAsync(x => x.DataCriacao.Month == mesAtual && x.DataCriacao.Year == anoAtual);
    }
}