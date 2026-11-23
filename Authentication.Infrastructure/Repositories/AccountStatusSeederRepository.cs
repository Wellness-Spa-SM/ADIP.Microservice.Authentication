using Authentication.Domain.Helpers.CodesTable;
using Authentication.Domain.Interfaces.Repositories;
using Authentication.Infrastructure.Contexts;
using TM.Common.Utils;
using AccountStatusEntity = Authentication.Domain.Models.Entities.CodesTable.AccountStatus;
using AccountStatusType = Authentication.Common.Constants.Enums.AccountStatus;

namespace Authentication.Infrastructure.Repositories
{
    public class AccountStatusSeederRepository : 
        Seeder<AuthenticationDbContext, AccountStatusEntity, string>,
        ISeederRepository
    {
        private readonly AuthenticationDbContext dbContext;
        private static IList<AccountStatusEntity> data =
        [
            AccountStatusHelper.Create(AccountStatusType.PendingVerification, "Pending Verification"),
            AccountStatusHelper.Create(AccountStatusType.Active, "Active"),
            AccountStatusHelper.Create(AccountStatusType.Locked, "Locked"),
            AccountStatusHelper.Create(AccountStatusType.Suspended, "Suspended"),
            AccountStatusHelper.Create(AccountStatusType.Disabled, "Disabled")
        ];

        public AccountStatusSeederRepository(AuthenticationDbContext dbContext) :
            base(data, dbContext, x => x.Code)
        {
            this.dbContext = dbContext;
        }

        public void Run()
        {
            this.Seed();
            this.dbContext.SaveChanges();
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            await this.SeedAsync(cancellationToken);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
