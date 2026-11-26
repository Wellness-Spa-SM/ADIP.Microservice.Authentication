using Authentication.Domain.Models.Entities;
using Authentication.Domain.Models.Entities.CodesTable;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using TM.Common.EntityFrameworkCore.Models.DataAccessObjects;
using Regex = Authentication.Common.Constants.RegEx;
namespace Authentication.Infrastructure.Contexts
{
    public class AuthenticationDbContext : IdentityDbContext<Account, Role, string>
    {
        #region ENTITIES
        public virtual Entity<Account> Accounts { get; private set; }

        #endregion

        #region Codes Table
        public virtual Entity<Role> Roles { get; set; }
        public virtual Entity<AccountStatus> AccountStatuses { get; set; }

        #endregion

        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) :
            base(options)
        {
            Accounts = new(Set<Account>());
            Roles = new(Set<Role>());
            AccountStatuses = new(Set<AccountStatus>());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // MODELS
            modelBuilder.Entity<Account>()
                .Ignore(a => a.LockoutEnabled)
                .Ignore(a => a.TwoFactorEnabled)
                .Ignore(a => a.AccessFailedCount)
                .Ignore(a => a.PhoneNumber)
                .Ignore(a => a.PhoneNumberConfirmed)
                .Ignore(a => a.EmailConfirmed)
                .Ignore(a => a.ConcurrencyStamp);

            modelBuilder.Entity<Account>(
                e => {
                    e.ToTable("Accounts");
                    e.Property(p => p.Id).HasMaxLength(Regex.Guid.MAX_LENGTH_1);
                });

            modelBuilder.Entity<Role>(
                e => {
                    e.ToTable("Roles");
                    e.Property(p => p.Id).HasMaxLength(Regex.Guid.MAX_LENGTH_1);
                });

            modelBuilder.Entity<AccountStatus>(
                e => {
                    e.HasIndex(e => e.Id).IsUnique();
                    e.ToTable("AccountStatuses");
                    e.Property(p => p.Id).HasMaxLength(Regex.Guid.MAX_LENGTH_1);
                });
        }
    }
}
