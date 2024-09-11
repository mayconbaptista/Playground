namespace Efcore.Request;

public record CustomerCreateRequest(uint zipCodePrefix, string city, string state);

public class CustomerRequest
{

}