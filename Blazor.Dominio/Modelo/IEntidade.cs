namespace Blazor.Dominio.Modelo
{
    public interface IEntidade
    {

    }


    public static class EntidadeExtensions
    {
        public static T Clone<T>(this T entity)
            where T : class, IEntidade, new()
        {
            T clone = new T();
            typeof(T).GetProperties()
                .Where(p => p.CanRead && p.CanWrite)
                .ToList()
                .ForEach(p => p.SetValue(clone, p.GetValue(entity)));
            return clone;
        }
    }
}
