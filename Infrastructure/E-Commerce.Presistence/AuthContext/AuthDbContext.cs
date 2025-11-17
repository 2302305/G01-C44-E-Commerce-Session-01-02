using E_Commerce.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace E_Commerce.Presistence.AuthContext
{
    internal class AuthDbContext(DbContextOptions<AuthDbContext> options)
        : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Address> Adresses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
