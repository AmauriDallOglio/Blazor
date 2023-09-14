namespace Blazor.Dominio.Modelo
{
    public class ResultadoOperacao 
    {
 
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; }
        //public ICollection<T> Modelos { get; set; }
 
        //public ResultadoOperacao(T modelo)
        //{
        //    Modelos.Add(modelo);
        //}

    }


    //public class MensagemOperacao
    //{
    //    public string Codigo { get; set; }
    //    public Exception Exception { get; set; }
    //    public string Mensagem { get; set; }
    //    public string Propriedade { get; set; }
    //    public TipoMensagemOperacaoEnumumerador Tipo { get; set; }
    //}

    public enum TipoMensagemOperacaoEnumumerador
    {
        Erro = 0,
        Alerta = 1,
        Info = 2,
        Sucesso = 3,
    }

    public class ResultadoOperacao<T> : ResultadoOperacao 
    {
        public T Modelo { get; set; }
        private ResultadoOperacao() { }
        public ResultadoOperacao(T modelo)
        {
            Modelo = modelo;
        }
    }
}
