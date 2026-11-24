using Authentication.Domain.Helpers.CodesTable;
using Authentication.Infrastructure.Contexts;
using TM.Common.Utils;
using AccountStatusEntity = Authentication.Domain.Models.Entities.CodesTable.AccountStatus;
using AccountStatusType = Authentication.Common.Constants.Enums.AccountStatus;

namespace Authentication.Infrastructure.Repositories
{
    public class AccountStatusSeederRepository(AuthenticationDbContext dbContext) : 
        Seeder<AuthenticationDbContext, AccountStatusEntity, string>
        (data, dbContext, x => x.Code)
    {
        private static IList<AccountStatusEntity> data =
        [
            AccountStatusHelper.Create(AccountStatusType.PendingVerification, "Pending Verification", id: "e0017ba0-f93b-4563-9ef9-571b508b3d4d"),
            AccountStatusHelper.Create(AccountStatusType.Active, "Active", id: "22b1ea87-492d-4ec5-88b6-fb9ce8746de9"),
            AccountStatusHelper.Create(AccountStatusType.Locked, "Locked", id: "f94db410-4b61-4ed8-b830-8dbdc8787b60"),
            AccountStatusHelper.Create(AccountStatusType.Suspended, "Suspended", id: "e6cc899a-f01e-440c-812c-7d106ed3bbfc"),
            AccountStatusHelper.Create(AccountStatusType.Disabled, "Disabled", id: "b0230fc5-624c-4e87-b46c-dd5281c132a7")
        ];
    }
}
