using Authentication.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TM.Common.EntityFrameworkCore.Models.Complex;

namespace Authentication.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task AddAsync(Account account, string password, CancellationToken cancellationToken);
        Task CreateAsync(Account account, string password, CancellationToken cancellationToken);
        Task<Account?> FindByNames(string firstName, string lastName, string username, CancellationToken cancellationToken);
    }
}
