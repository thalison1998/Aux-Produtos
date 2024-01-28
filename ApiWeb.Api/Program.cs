using ApiWeb.Api.Extensions;
using ApiWeb.Infra.CrossCutting.IoC;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning | LogLevel.Error)
        .AddConsole();
});


builder.Services
    .InjetarDependenciasApi(builder.Configuration, loggerFactory)
    //.AddAuthentication(builder.Configuration)
    .AddVersioning()
    .AddSwagger();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseRouting();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
