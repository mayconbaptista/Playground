namespace Efcore.Exceptions;

public sealed class BadRequestException : Exception
{
    public List<string> Erros { get; private set; }

    public BadRequestException(List<string> erros) : base ("Erro na validação")
    { 
        this.Erros = erros;
    }
}
