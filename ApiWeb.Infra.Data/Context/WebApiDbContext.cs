using ApiWeb.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiWeb.Infra.Data.Context;

public class WebApiDbContext : DbContext
{
    public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) { }

    public DbSet<Transacao> Transacao { get; set; }
    public DbSet<RegistroFinanceiro> RegistroFinanceiro { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        builder.ToSnakeCaseNames();
    }
}