using Efcore.Exceptions;

namespace Efcore.Validation;

public class ValidationDomain
{
    private List<string> Errors;

    public ValidationDomain() 
    {
        this.Errors = new List<string>();
    }

    public void when (bool check, string message)
    {
        if (!check)
        {
            this.Errors.Add(message);
        }
    }

    public void Execute ()
    {
        if(this.Errors.Any())
        {
            throw new DomainException(Errors);
        }
    }
}
