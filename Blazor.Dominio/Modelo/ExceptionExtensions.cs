namespace Blazor.Dominio.Modelo
{
    public static class ExceptionExtensions
    {
        public static IEnumerable<string> AllMessages(this Exception ex)
        {
            yield return ex.Message;
            AggregateException ex2;
            if ((ex2 = ex as AggregateException) != null)
            {
                foreach (Exception innerException in ex2.InnerExceptions)
                {
                    foreach (string item in innerException.AllMessages())
                    {
                        yield return item;
                    }
                }
            }
            else
            {
                for (Exception inner = ex.InnerException; inner != null; inner = inner.InnerException)
                {
                    yield return inner.Message;
                }
            }
        }
    }
}
