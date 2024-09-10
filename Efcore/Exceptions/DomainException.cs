using System.Text;

namespace Efcore.Exceptions
{
    public sealed class DomainException : Exception
    {
        public List<string> Erros { get; private set; }

        public DomainException(List<string> erros) : base ("Erro na validação")
        { 
            this.Erros = erros;
        }
    }
}
