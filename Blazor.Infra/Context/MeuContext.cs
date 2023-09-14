using Blazor.Dominio.Entidade;
using Blazor.Infra.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Infra.Context
{
    public class MeuContext : DbContext
    {
        public MeuContext(DbContextOptions<MeuContext> options) : base(options)
        {

        }

        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Auditoria> Auditoria { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfiguracaoMapeamento.Injetar(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

    }
}
