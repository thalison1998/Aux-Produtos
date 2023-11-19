using ApiWeb.Domain.Domains;
using ApiWeb.Domain.Interfaces.IRepository;
using ApiWeb.Infra.Data.Context;

namespace ApiWeb.Infra.Data.Repository;

public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
{
    public TransacaoRepository(WebApiDbContext context) : base(context) { }
}
