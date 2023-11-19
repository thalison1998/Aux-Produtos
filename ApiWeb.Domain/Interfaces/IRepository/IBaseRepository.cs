using ApiWeb.Domain.Domains;

namespace ApiWeb.Domain.Interfaces.IRepository;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : Base
{
    TEntity Adicionar(TEntity obj);
    Task<TEntity> ObterPorIdAsync(Guid id);
    Task<IEnumerable<TEntity>> ObterTodosAsync();
    void Atualizar(TEntity obj);
    Guid Remover(TEntity entity);
}
