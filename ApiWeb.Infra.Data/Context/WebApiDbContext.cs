
using ApiWeb.Domain.EntidadeAbstract;
using ApiWeb.Domain.Entidades.GrupoRegistroFinanceiro;
using ApiWeb.Domain.Entidades.RegistroFinanceiro;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiWeb.Infra.Data.Context;

public class WebApiDbContext : DbContext
{
    public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) { }

    public DbSet<OperacaoEntrada> OperacoesEntrada { get; set; }
    public DbSet<OperacaoSaida> OperecoesSaida { get; set; }
    public DbSet<RegistroFinanceiro> RegistroFinanceiro { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        builder.ToSnakeCaseNames();
    }
}