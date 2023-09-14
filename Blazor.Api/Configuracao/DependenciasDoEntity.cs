using Blazor.Aplicacao.Aplicacao;
using Blazor.Aplicacao.Interface;
using Blazor.Dominio.InterfaceRepositorio;
using Blazor.Infra.Repositorio;

namespace Blazor.Api.Configuracao
{
    public static class DependenciasDoEntity
    {
        public static void Injetar(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ITenantRepositorioGen, TenantRepositorioGen>();
            builder.Services.AddScoped<ITenantRepositorioGen, TenantRepositorioGen>();

            builder.Services.AddTransient<IAuditoriaRepositorioGen, AuditoriaRepositorioGen>();
            builder.Services.AddScoped<IAuditoriaRepositorioGen, AuditoriaRepositorioGen>();


            builder.Services.AddScoped<ITenantRepositorio, TenantRepositorio>();
            builder.Services.AddScoped<TenantAplicacao>();
            builder.Services.AddScoped<ITenantAplicacao, TenantAplicacao>();

            builder.Services.AddScoped<IAuditoriaRepositorio, AuditoriaRepositorio>();
            builder.Services.AddScoped<AuditoriaAplicacao>();
            builder.Services.AddScoped<IAuditoriaAplicacao, AuditoriaAplicacao>();
        }
    }
}
