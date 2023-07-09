using ApiWeb.Domain.Entidades;
using ApiWeb.Domain.Interfaces.IRepository;
using ApiWeb.Infra.Data.Context;

namespace ApiWeb.Infra.Data.Repository;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(WebApiDbContext context) : base(context) { }
}