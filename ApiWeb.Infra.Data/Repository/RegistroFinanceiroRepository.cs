using ApiWeb.Domain.EntidadeAbstract;
using ApiWeb.Domain.Entidades.GrupoRegistroFinanceiro;
using ApiWeb.Domain.Interfaces.IRepository;
using ApiWeb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Infra.Data.Repository;

public class RegistroFinanceiroRepository : BaseRepository<RegistroFinanceiro>, IRegistroFinanceiroRepository
{
    public RegistroFinanceiroRepository(WebApiDbContext context) : base(context) { }

    public async Task<RegistroFinanceiro?> ObterPorIdComOperacaoAsync(Guid registroFinanceiroId)
    {
        return await Obter().Include(x => x.Operacoes).FirstOrDefaultAsync(x => x.Id == registroFinanceiroId);
    }
}