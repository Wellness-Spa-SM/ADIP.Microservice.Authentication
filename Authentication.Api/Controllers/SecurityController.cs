using Microsoft.AspNetCore.Mvc;
using TM.Common.Utils;
using Authentication.Application.Services.Interfaces;
using Authentication.Application.Models.Dtos;

namespace Authentication.Api.Controllers
{
    [Route("api/security/hidden")]
    [ApiController]
    //[Host("*:5050")]
    //[Authorize]
    public class SecurityController : ControllerBase
    {
        private readonly ISeederService seederService;
        private readonly IAccountService accountService;

        public SecurityController(ISeederService seederService, IAccountService accountService)
        {
            this.seederService = seederService;
            this.accountService = accountService;
        }

        [HttpPost("hash/{prefix}/{idIteration:int}/{count:int}/{isExtended:bool}")]
        public IList<string> GetHash(string prefix = "", int idIteration = 1, int count = 1, bool isExtended = false)
        {
            var list = new List<string>();
            for (int x = 0; x<count; x++)
                list.Add(isExtended? Security.GenerateExtendedGuid(prefix, idIteration) : Guid.NewGuid().ToString());

            return list;
        }

        [HttpPost("account")]
        public async Task<string> CreateAccount([FromBody] CreateAccountDto data, CancellationToken cancellationToken)
        {
            await accountService.CreateAccount(data, cancellationToken);
            return "Success";
        }

        [HttpPost("seed/async")]
        public async Task<string> SeedAccountTypesAsync(CancellationToken cancellationToken)
        {
            await seederService.RunAsync(cancellationToken);
            return "Success";
        }

        [HttpPost("seed")]
        public string SeedAccountTypes(CancellationToken cancellationToken)
        {
            seederService.Run(cancellationToken);
            return "Success";
        }
    }
}
