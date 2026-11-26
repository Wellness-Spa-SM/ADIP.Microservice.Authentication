using Authentication.Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using TM.Common.EntityFrameworkCore.Models.Complex;

namespace Authentication.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<TaskResult> CreateAccount(CreateAccountDto data, CancellationToken cancellationToken);
        Task<TaskResult> UpdateAccountPasswordByEmailAsync(UpdateAccountPasswordDto data, CancellationToken cancellationToken);
        Task<TaskResult> UnsecureUpdateAccountPasswordByEmailAsync(UnsecureUpdateAccountPasswordDto data, CancellationToken cancellationToken);
    }
}
