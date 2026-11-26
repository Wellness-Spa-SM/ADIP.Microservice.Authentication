using Authentication.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Interfaces.Repositories
{
    public interface IUnsecureAccountRepository
    {
        Task UpdatePasswordAsync(Account? account, string newPasswordHashed, CancellationToken cancellationToken);
    }
}
