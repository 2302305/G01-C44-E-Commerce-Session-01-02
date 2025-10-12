namespace E_Commerce.Domain.Entities
{
    public abstract class Entity<Tkey>
    {
        public Tkey Id { get; set; } = default!;
    }
}
