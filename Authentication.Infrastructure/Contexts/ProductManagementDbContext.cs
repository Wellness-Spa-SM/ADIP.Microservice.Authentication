using Microsoft.EntityFrameworkCore;
using Authentication.Domain.Models.Entities;
using Authentication.Domain.Models.Entities.CodesTable;

namespace Authentication.Infrastructure.Contexts
{
    public class AuthenticationDbContext : DbContext
    {
        #region ENTITIES
        public virtual DbSet<Product> Products { get; set; }

        #endregion

        #region CODESTABLE
        public virtual DbSet<ProductType> ProductTypes { get; set; }

        #endregion

        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
