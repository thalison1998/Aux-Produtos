
using ApiWeb.Domain.Interfaces;
using ApiWeb.Infra.Data.Context;

namespace ApiWeb.Infra.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly WebApiDbContext _context;

    public UnitOfWork(WebApiDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}

