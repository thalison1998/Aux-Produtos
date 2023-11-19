using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ApiWeb.Domain.Interfaces.IRepository;
using ApiWeb.Infra.Data.Context;
using ApiWeb.Domain.Domains;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Base
{
    protected WebApiDbContext Db;
    protected DbSet<TEntity> DbSet;

    public BaseRepository(WebApiDbContext context)
    {
        Db = context;
        DbSet = Db.Set<TEntity>();
    }

    public virtual TEntity Adicionar(TEntity obj)
    {
        EntityEntry<TEntity> objreturn = DbSet.Add(obj);
        return objreturn.Entity;
    }

    public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public virtual void Atualizar(TEntity obj)
    {
        Db.Entry(obj).State = EntityState.Modified;

        DbSet.Update(obj);
    }

    public virtual Guid Remover(TEntity entity)
    {
        if (Db.Entry(entity).State == EntityState.Detached)
            DbSet.Attach(entity);

        DbSet.Remove(entity);
        return entity.Id;
    }

    protected virtual IQueryable<TEntity> Obter()
    {
        return DbSet;
    }

    protected virtual IQueryable<TEntity> ObterAsNoTracking()
    {
        return DbSet.AsNoTrackingWithIdentityResolution();
    }

    public void Dispose()
    {
        Db.Dispose();
        GC.SuppressFinalize(this);
    }
}
