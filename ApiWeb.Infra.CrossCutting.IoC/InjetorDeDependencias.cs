using ApiWeb.Application.AppService;
using ApiWeb.Application.AppService.Interface;
using ApiWeb.Application.AutoMapper;
using ApiWeb.Domain.Interfaces;
using ApiWeb.Domain.Interfaces.IRepository;
using ApiWeb.Infra.Data;
using ApiWeb.Infra.Data.Context;
using ApiWeb.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static ApiWeb.Application.Validadores.Validadores;

namespace ApiWeb.Infra.CrossCutting.IoC;

public static class InjetorDeDependencias
{
    public static IServiceCollection InjetarDependenciasApi(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        services.AddScoped<ErrorHandlingMiddleware>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(typeof(AutoMapperConfig));

        return services
            .InjetarDbContext(configuration, loggerFactory)
            .InjetarAppServices()
            .InjetarRepository();
            //.InjetarValidadores();

    }

    //private static IServiceCollection InjetarValidadores(this IServiceCollection services)
    //{
    //    services.AddTransient<IValidator<CriarOperacaoRequest>, CriarOperacaoValidator>();
    //    return services;
    //}


    private static IServiceCollection InjetarAppServices(this IServiceCollection services)
    {
        services.AddScoped<IProdutoAppService,ProdutoAppService>();

        return services;
    }

    private static IServiceCollection InjetarRepository(this IServiceCollection services)
    {
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        return services;
    }
    private static IServiceCollection InjetarDbContext(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        services.AddDbContext<WebApiDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            .UseLoggerFactory(loggerFactory);
        });

        return services;
    }
}