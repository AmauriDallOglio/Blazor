using Blazor.Dominio.Modelo;
using Blazor.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Infra.Modelo
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    {
        private readonly MeuContext _dbContext;

        public RepositorioGenerico(MeuContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Alterar(TEntity entidade, bool finalizar)
        {
            _dbContext.Entry(entidade).State = EntityState.Modified;
            _dbContext.Set<TEntity>().Update(entidade);
            if (finalizar)
            {
                Comitar();
            }
            return entidade;
        }

        public void Comitar()
        {
            _dbContext.SaveChanges();
        }

        public TEntity Deletar(TEntity entidade)
        {
            _dbContext.Set<TEntity>().Remove(entidade);
            Comitar();
            return entidade;
        }

        public TEntity Inserir(TEntity entidade, bool finalizar)
        {
            _dbContext.Set<TEntity>().Add(entidade);
            if (finalizar)
            {
                Comitar();
            }
            return entidade;
        }

        public TEntity ObterPorId(object id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> ObterTodos()
        {
            return _dbContext.Set<TEntity>();
        }
    }
}
