namespace E_Commerce.Service.Exceptions
{
    public abstract class NotFoundExceptions(string message) : Exception(message);
    public sealed class ProductNotFoundException(int Id) : NotFoundExceptions($"Product with Id {Id} is Not Found");
    public sealed class CartFoundException(string Id) : NotFoundExceptions($"Cart with Id {Id} is Not Found");
}
