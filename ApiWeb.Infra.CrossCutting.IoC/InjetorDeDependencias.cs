using ApiWeb.Application.AppService;
using ApiWeb.Application.AppService.Interface;
using ApiWeb.Application.AutoMapper;
using ApiWeb.Domain.Interfaces;
using ApiWeb.Domain.Interfaces.IRepository;
using ApiWeb.Domain.Service;
using ApiWeb.Domain.Service.Interface;
using ApiWeb.Infra.Data;
using ApiWeb.Infra.Data.Context;
using ApiWeb.Infra.Data.Repository;
using Identity.Data;
using Identity.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ApiWeb.Infra.CrossCutting.IoC;

public static class InjetorDeDependencias
{
    public static IServiceCollection InjetarDependenciasApi(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        services.AddScoped<ErrorHandlingMiddleware>();
        services.AddScoped<IIdentityAppService, IdentityService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(typeof(AutoMapperConfig));

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityDataContext>()
            .AddDefaultTokenProviders();

        return services
            .InjetarDbContext(configuration, loggerFactory)
            .InjetarAppServices()
            .InjetarServices()
            .InjetarRepository();
    }

    private static IServiceCollection InjetarAppServices(this IServiceCollection services)
    {
        services.AddScoped<IRegistroFinanceiroAppService, RegistroFinanceiroAppService>();
        services.AddScoped<ITransacaoAppService, TransacaoAppService>();

        return services;
    }
    private static IServiceCollection InjetarServices(this IServiceCollection services)
    {
        services.AddScoped<IRegistroFinanceiroService, RegistroFinanceiroService>();
        services.AddScoped<ITransacaoService, TransacaoService>();

        return services;
    }

    private static IServiceCollection InjetarRepository(this IServiceCollection services)
    {
        services.AddScoped<IRegistroFinanceiroRepository, RegistroFinanceiroRepository>();
        services.AddScoped<ITransacaoRepository, TransacaoRepository>();

        return services;
    }
    private static IServiceCollection InjetarDbContext(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        services.AddDbContext<WebApiDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            .UseLoggerFactory(loggerFactory);
        });

        services.AddDbContext<IdentityDataContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            .UseLoggerFactory(loggerFactory);
        });

        return services;
    }
}