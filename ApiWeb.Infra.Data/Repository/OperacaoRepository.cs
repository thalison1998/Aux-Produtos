using ApiWeb.Domain.EntidadeAbstract;
using ApiWeb.Domain.Interfaces.IRepository;
using ApiWeb.Infra.Data.Context;

namespace ApiWeb.Infra.Data.Repository;

public class OperacaoRepository : BaseRepository<Operacao>, IOperacaoRepository
{
    public OperacaoRepository(WebApiDbContext context) : base(context) { }
}