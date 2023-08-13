using Blazor.Aplicacao.Aplicacao;
using Blazor.Aplicacao.Interface;
using Blazor.Dominio.Commands.Tenant.Create;
using Blazor.Dominio.CQRS.Tenant.Find;
using Blazor.Dominio.InterfaceRepositorio;
using Blazor.Infra.Context;
using Blazor.Infra.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); // Habilita o uso de anotações para documentar o Swagger
    // Restante da configuração do Swagger...
});




builder.Services.AddDbContext<MeuContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));


builder.Services.AddTransient<ICreateTenantHandler, CreateTenantHandler>();
builder.Services.AddTransient<IFindTenantHandler, FindTenantHandler>();




builder.Services.AddScoped<ITenantRepositorio, TenantRepositorio>();
builder.Services.AddScoped<TenantAplicacao>();
builder.Services.AddScoped<ITenantAplicacao, TenantAplicacao>();

builder.Services.AddScoped<IAuditoriaRepositorio, AuditoriaRepositorio>();
builder.Services.AddScoped<AuditoriaAplicacao>();
builder.Services.AddScoped<IAuditoriaAplicacao, AuditoriaAplicacao>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
