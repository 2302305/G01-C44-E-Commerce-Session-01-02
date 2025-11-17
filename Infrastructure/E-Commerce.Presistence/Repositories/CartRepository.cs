using E_Commerce.Domain.Entities.Cart;
using StackExchange.Redis;
using System.Text.Json;

namespace E_Commerce.Presistence.Repositories
{
    internal class CartRepository(IConnectionMultiplexer connectionMultiplexer) : ICartRepository
    {
        private readonly IDatabase _database = connectionMultiplexer.GetDatabase();
        public async Task<bool> DeleteAsync(string Id)
        {
            return await _database.KeyDeleteAsync(Id);
        }

        public async Task<CustomerCart> GetCartByIdAsync(string Id)
        {
            var json = await _database.StringGetAsync(Id);
            if (json.IsNullOrEmpty)
            {
                return null;
            }
            return JsonSerializer.Deserialize<CustomerCart>(json!)!;
        }

        public async Task<CustomerCart> UpdateAndCreateAsync(CustomerCart customerCart, TimeSpan? Ttl = null)
        {
            var json = JsonSerializer.Serialize(customerCart);
            await _database.StringSetAsync(customerCart.Id, json, Ttl ?? TimeSpan.FromDays(20));
            return await GetCartByIdAsync(customerCart.Id);
        }
    }
}
