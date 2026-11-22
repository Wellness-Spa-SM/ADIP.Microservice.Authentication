using Authentication.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TM.Common.Utils;
using Microsoft.AspNetCore.Authorization;
using Authentication.Infrastructure.Seeders;
using Authentication.Infrastructure.Contexts;

namespace Authentication.Api.Controllers
{
    [Route("api/security")]
    [ApiController]
    //[Host("*:5050")]
    //[Authorize]
    public class SecurityController(AuthenticationDbContext dbContext) : ControllerBase
    {
        [HttpPost("hidden/hash/{prefix}/{idIteration:int}/{count:int}/{isExtended:bool}")]
        [AllowAnonymous]
        public IList<string> GetHash(string prefix = "", int idIteration = 1, int count = 1, bool isExtended = false)
        {
            var list = new List<string>();
            for (int x = 0; x<count; x++)
                list.Add(isExtended? Security.GenerateExtendedGuid(prefix, idIteration) : Guid.NewGuid().ToString());

            return list;
        }

        [HttpPost("hidden/account")]
        public Task<string> CreateAccount([FromBody] CreateAccountOnlyDto data)
        {
            return null;
        }

        [HttpPost("hidden/account/type/seed")]
        public async Task<string> SeedAccountTypes()
        {
            new AccountStatusSeeder(dbContext).Seed();
            await dbContext.SaveChangesAsync();

            return "Success";
        }
    }
}
