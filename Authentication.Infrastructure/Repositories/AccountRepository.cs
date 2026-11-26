using Authentication.Domain.Interfaces.Repositories;
using Authentication.Domain.Models.Entities;
using Authentication.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure.Repositories
{
    internal class AccountRepository(
        AuthenticationDbContext dbContext, 
        UserManager<Account> userManager, 
        IPasswordHasher<Account> passwordHasher
    ) : IAccountRepository
    {
        public async Task AddAsync(Account account, string password, CancellationToken cancellationToken)
        {
            var passwordHashed = passwordHasher.HashPassword(account, password);
            account.PasswordHash = passwordHashed;

            await dbContext.Accounts.Source.AddAsync(account, cancellationToken);
        }

        public async Task CreateAsync(Account account, string password, CancellationToken cancellationToken)
        {
            var result = await userManager.CreateAsync(account, password);
            if (!result.Succeeded)
                throw new Exception(result.Errors.ToString());
        }

        public async Task<Account?> FindByNames(string firstName, string lastName, string username, CancellationToken cancellationToken) => 
            await dbContext.Accounts.Untracked.FirstOrDefaultAsync(a => 
                a.FirstName.ToLower() == firstName.ToLower()
                && a.LastName.ToLower() == lastName.ToLower()
                && a.NormalizedUserName == username.ToUpper()
            );
    }
}
