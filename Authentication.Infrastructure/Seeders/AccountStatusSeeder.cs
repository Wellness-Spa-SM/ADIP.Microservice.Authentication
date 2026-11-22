using Authentication.Domain.Helpers.CodesTable;
using Authentication.Domain.Models.Entities.CodesTable;
using Authentication.Infrastructure.Contexts;
using Authentication.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using AccountStatusType = Authentication.Common.Constants.Enums.AccountStatus;
using AccountStatusEntity = Authentication.Domain.Models.Entities.CodesTable.AccountStatus;

namespace Authentication.Infrastructure.Seeders
{
    public class AccountStatusSeeder : 
        Seeder<AuthenticationDbContext, AccountStatusEntity, string>
    {
        private static IList<AccountStatusEntity> data =
        [
            AccountStatusHelper.Create(AccountStatusType.PendingVerification, "Pending Verification"),
            AccountStatusHelper.Create(AccountStatusType.Active, "Active"),
            AccountStatusHelper.Create(AccountStatusType.Locked, "Locked"),
            AccountStatusHelper.Create(AccountStatusType.Suspended, "Suspended"),
            AccountStatusHelper.Create(AccountStatusType.Disabled, "Disabled")
        ];

        public AccountStatusSeeder(AuthenticationDbContext dbContext) : base(data, dbContext, x => x.Code) { }
    }
}
