using Authentication.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using TM.Common.Utils;
using Authentication.Application.Services.Interfaces;

namespace Authentication.Api.Controllers
{
    [Route("api/security/hidden")]
    [ApiController]
    //[Host("*:5050")]
    //[Authorize]
    public class SecurityController(ISeederService seederService) : ControllerBase
    {
        [HttpPost("hidden/hash/{prefix}/{idIteration:int}/{count:int}/{isExtended:bool}")]
        public IList<string> GetHash(string prefix = "", int idIteration = 1, int count = 1, bool isExtended = false)
        {
            var list = new List<string>();
            for (int x = 0; x<count; x++)
                list.Add(isExtended? Security.GenerateExtendedGuid(prefix, idIteration) : Guid.NewGuid().ToString());

            return list;
        }

        [HttpPost("account")]
        public Task<string> CreateAccount([FromBody] CreateAccountOnlyDto data)
        {
            return null;
        }

        [HttpPost("account/seed/type/async")]
        public async Task<string> SeedAccountTypesAsync(CancellationToken cancellationToken)
        {
            await seederService.RunAsync(cancellationToken);
            return "Success";
        }

        [HttpPost("account/seed/type")]
        public string SeedAccountTypes(CancellationToken cancellationToken)
        {
            seederService.Run(cancellationToken);
            return "Success";
        }
    }
}
