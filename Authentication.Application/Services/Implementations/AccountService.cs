using Authentication.Application.Helpers;
using Authentication.Application.Models.Dtos;
using Authentication.Application.Services.Interfaces;
using Authentication.Common;
using Authentication.Domain.Interfaces.Repositories;
using Authentication.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using TM.Common.EntityFrameworkCore.Models.Complex;
using TM.Common.Utils;

namespace Authentication.Application.Services.Implementations
{
    public class AccountService(
        IAccountRepository accountRepository,
        IUnsecureAccountRepository unsecureAccountRepository,
        IMasterRepository masterRepository,
        UserManager<Account> userManager) : 
        IAccountService
    {
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

        public async Task<TaskResult> UnsecureUpdateAccountPasswordByEmailAsync(UnsecureUpdateAccountPasswordDto data, CancellationToken cancellationToken)
        {
            try
            {
                var email = Utils.NormalizeString(data.Email);
                var account = await userManager.FindByEmailAsync(email);
                Guard.AgainstNull(account, "Account does not exist");

                await unsecureAccountRepository.UpdatePasswordAsync(account, data.NewPassword, cancellationToken);
                await masterRepository.SaveAsync(cancellationToken);

                return TaskResult.Success("Account Password Updated in unsecure way");
            }
            catch (Exception ex)
            {
                return TaskResult.Fail(ex.Message);
            }
        }

        public async Task<TaskResult> UpdateAccountPasswordByEmailAsync(UpdateAccountPasswordDto data, CancellationToken cancellationToken)
        {
            try
            {
                var email = Utils.NormalizeString(data.Email);
                var account = await userManager.FindByEmailAsync(email);
                Guard.AgainstNull(account, "Account does not exist");

                var result = await userManager.ChangePasswordAsync(account, data.OldPassword, data.NewPassword);
                Guard.ThrowInvalidOperationIf(!result.Succeeded, result.Errors.Select(e => e.Description).FirstOrDefault() ?? "Failed to change password");

                return TaskResult.Success("Account Password Updated");
            }
            catch (Exception ex)
            {
                return TaskResult.Fail(ex.Message);
            }
        }
    }
}
