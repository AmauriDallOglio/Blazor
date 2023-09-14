using System.Runtime.Serialization;

namespace Blazor.Dominio.Modelo
{
    [Serializable]
    public class ServicoException : Exception, ISerializable
    {

        public string Codigo { get; set; }

   
        public ServicoException()
            : this(string.Empty, string.Empty, null)
        {
        }


        public ServicoException(string message)
            : this(message, string.Empty, null)
        {
        }

        public ServicoException(string message, Exception inner)
            : this(message, string.Empty, inner)
        {
        }


        public ServicoException(string message, string codigo)
            : this(message, codigo, null)
        {
        }


        public ServicoException(Exception inner, string codigo)
            : this(inner.Message, codigo, inner)
        {
        }


        public ServicoException(string message, string codigo, Exception inner)
            : base(message, inner)
        {
            Codigo = codigo;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Codigo", Codigo);
        }
    }
}
