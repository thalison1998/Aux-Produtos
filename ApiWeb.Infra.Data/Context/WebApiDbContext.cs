using ApiWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiWeb.Infra.Data.Context;

public class WebApiDbContext : DbContext
{
    public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) { }

    public DbSet<Produto> Produto{ get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        builder.ToSnakeCaseNames();
    }
}