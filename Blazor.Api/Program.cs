using AutoMapper;
using Blazor.Api.Configuracao;
using Blazor.AplicacaoCqrsMediator.CQRS.Tenant.Create;
using Blazor.AplicacaoCqrsMediator.CQRS.Tenant.Find;
using Blazor.Infra.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

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
 
string connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");
builder.Services.AddDbContext<MeuContext>(options => options.UseSqlServer(connectionString));

 
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddHttpClient();
builder.Services.AddHealthChecks();

DependenciasDoEntity.Injetar(builder);

var config = new MapperConfiguration(cfg =>
{
    DependenciasDoMapper.Injetar(cfg);
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddCors();

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

///Declara as dependencias do CQRS
builder.Services.AddTransient<ICreateTenantHandler, CreateTenantHandler>();
builder.Services.AddTransient<IFindTenantHandler, FindTenantHandler>();

 
 
 
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
