using Authentication.Domain.Interfaces.Repositories;
using Authentication.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure.Repositories
{
    public class MasterRepository(AuthenticationDbContext dbContext) : IMasterRepository
    {
        public async Task SaveAsync(CancellationToken cancellation) => await dbContext.SaveChangesAsync(true, cancellation);
    }
}
