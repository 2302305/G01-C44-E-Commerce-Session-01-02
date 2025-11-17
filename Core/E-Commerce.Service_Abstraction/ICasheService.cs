namespace E_Commerce.Service_Abstraction
{
    public interface ICasheService
    {
        Task<string?> GetAsync(string key);
        Task SetAsync(string key, object value, TimeSpan? Ttl = null);
    }
}
