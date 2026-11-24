using Authentication.Application.Helpers;
using Authentication.Application.Models.Dtos;
using Authentication.Application.Services.Interfaces;
using Authentication.Domain.Interfaces.Repositories;
using Authentication.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using TM.Common.EntityFrameworkCore.Models.Complex;

namespace Authentication.Application.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly UserManager<Account> userManager;

        public AccountService(IAccountRepository accountRepository, UserManager<Account> userManager)
        {
            this.accountRepository = accountRepository;
            this.userManager = userManager;
        }

        public async Task<TaskResult> CreateAccount(CreateAccountDto data, CancellationToken cancellationToken)
        {
            try
            {
                var account = AccountHelper.ToAccount(data);
                await accountRepository.CreateAsync(account, data.Password, cancellationToken);

                return TaskResult.Success("Created Account Successfully");
            }
            catch (Exception ex)
            {
                return TaskResult.Fail(ex.Message);
            }
        }
    }
}
