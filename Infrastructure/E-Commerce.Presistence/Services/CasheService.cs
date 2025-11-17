using System.Text.Json;

namespace E_Commerce.Presistence.Services
{
    public class CasheService(IConnectionMultiplexer connectionMultiplexer) : ICasheService
    {
        private readonly IDatabase database = connectionMultiplexer.GetDatabase();

        public async Task<string?> GetAsync(string key)
        {
            return await database.StringGetAsync(key);
        }

        public async Task SetAsync(string key, object value, TimeSpan? Ttl = null)
        {
            //var option = new JsonSerializerOptions
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //};
            var json = JsonSerializer.Serialize(value);
            await database.StringSetAsync(key, json, Ttl);
        }
    }
}
