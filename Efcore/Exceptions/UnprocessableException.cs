namespace Efcore.Exceptions
{
    public sealed class UnprocessableException : Exception
    {
        public UnprocessableException(string message) : base(message)
        {
        }
    }
}
