using Authentication.Domain.Interfaces.Repositories;
using Authentication.Domain.Models.Entities;
using Authentication.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TM.Common.Utils;

namespace Authentication.Infrastructure.Repositories
{
    public class UnsecureAccountRepository(AuthenticationDbContext dbContext, IPasswordHasher<Account> passwordHasher) : IUnsecureAccountRepository
    {
        public async Task UpdatePasswordAsync(Account? account, string newPasswordHashed, CancellationToken cancellationToken)
        {
            Guard.AgainstNullOrEmpty(newPasswordHashed, "New Password hashed is empty or null");
            Guard.AgainstNull(account, "Account not found or doesnt exist");

            account!.PasswordHash = passwordHasher.HashPassword(account, newPasswordHashed);
            cancellationToken.ThrowIfCancellationRequested();
            dbContext.Accounts.Source.Update(account!);
        }
    }
}
