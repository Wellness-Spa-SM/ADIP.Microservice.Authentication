using Microsoft.AspNetCore.Mvc;
using TM.Common.Utils;
using Authentication.Application.Services.Interfaces;
using Authentication.Application.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Authentication.Domain.Models.Entities;
using TM.Common.EntityFrameworkCore.Models.Complex;
using TM.Common.Utils.Interfaces;

namespace Authentication.Api.Controllers
{
    [Route("api/security/hidden")]
    [ApiController]
    //[Host("*:5050")]
    //[Authorize]
    public class SecurityController : ControllerBase
    {
        private readonly ISeederManager seederManager;
        private readonly IAccountService accountService;
        private readonly IPasswordHasher<Account> passwordHasher;

        public SecurityController(ISeederManager seederManager, IAccountService accountService, IPasswordHasher<Account> passwordHasher)
        {
            this.seederManager = seederManager;
            this.accountService = accountService;
            this.passwordHasher = passwordHasher;
        }

        [HttpPost("hash/{prefix}/{idIteration:int}/{count:int}/{isExtended:bool}")]
        public IList<string> GetHash(string prefix = "", int idIteration = 1, int count = 1, bool isExtended = false)
        {
            var list = new List<string>();
            for (int x = 0; x<count; x++)
                list.Add(isExtended? Security.GenerateExtendedGuid(prefix, idIteration) : Guid.NewGuid().ToString());

            return list;
        }

        [HttpPost("hash/password")]
        public string GetPasswordHash([FromBody] string plainTextPassword)
        {
            return passwordHasher.HashPassword(null, plainTextPassword);
        }

        [HttpPatch("account/password")]
        public Task<TaskResult> UpdatePasswordHash([FromBody] UnsecureUpdateAccountPasswordDto data, CancellationToken cancellationToken)
        {
            return accountService.UnsecureUpdateAccountPasswordByEmailAsync(data, cancellationToken);
        }

        [HttpPost("seed/async")]
        public async Task<string> SeedAsync(CancellationToken cancellationToken)
        {
            await seederManager.RunAsync(cancellationToken);
            return "Success";
        }

        [HttpPost("seed")]
        public string Seed(CancellationToken cancellationToken)
        {
            seederManager.Run(cancellationToken);
            return "Success";
        }
    }
}
