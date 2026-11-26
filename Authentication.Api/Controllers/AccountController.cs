using Authentication.Application.Models.Dtos;
using Authentication.Application.Services.Implementations;
using Authentication.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TM.Common.EntityFrameworkCore.Models.Complex;

namespace Authentication.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        public async Task<TaskResult> CreateAccount([FromBody] CreateAccountDto data, CancellationToken cancellationToken)
        {
            return await accountService.CreateAccount(data, cancellationToken);
        }

        [HttpPatch]
        public async Task<TaskResult> UpdateAccountPassword([FromBody] UpdateAccountPasswordDto data, CancellationToken cancellationToken)
        {
            return await accountService.UpdateAccountPasswordByEmailAsync(data, cancellationToken);
        }

    }
}
