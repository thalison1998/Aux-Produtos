using ApiWeb.Domain.Entidades;

namespace ApiWeb.Domain.Interfaces.IRepository;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : Base
{
    TEntity Adicionar(TEntity obj);
    Task<TEntity> ObterPorIdAsync(Guid id);
    Task<IEnumerable<TEntity>> ObterTodosAsync();
    void Atualizar(TEntity obj);
    void Remover(TEntity entity);
}
