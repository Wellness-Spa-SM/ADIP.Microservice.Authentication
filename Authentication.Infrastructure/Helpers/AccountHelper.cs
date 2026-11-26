using Authentication.Common.Constants;
using Authentication.Domain.Models.Entities;
using Authentication.Domain.Models.Entities.CodesTable;
using Authentication.Infrastructure.Models.Complex;
using Microsoft.AspNetCore.Identity;
using TM.Common.Utils;
using Types = Authentication.Common.Constants.Enums;

namespace Authentication.Infrastructure.Helpers
{
    public class AccountHelper
    {
        public static AccountStatus CreateStatus(
            Types.AccountStatus code,
            string title,
            Guid? id = null,
            string creator = StaticDetail.DOMAIN_SYSTEM,
            int priority = StaticDetail.PRIORITY_DEFAULT
        )
        {
            return new AccountStatus
            {
                Id = id ?? Guid.NewGuid(),
                Code = code.ToString(),
                Title = title,
                Priority = priority,
                CreatedBy = creator,
                DateTimeCreated = DateTime.Now,
                ModifiedBy = creator,
                DateTimeModified = DateTime.Now,
                IsActive = true,
            };
        }

        public static AccountStatus CreateStatus(
            Types.AccountStatus code,
            string title,
            string? id = null,
            string creator = StaticDetail.DOMAIN_SYSTEM,
            int priority = StaticDetail.PRIORITY_DEFAULT
        )
        {
            return CreateStatus(code, title, Guid.Parse(id), creator, priority);
        }

        public static Account CreateAccount(
            string openId,
            string firstName,
            string lastName,
            string username,
            string email,
            string password,
            string? id = null
        )
        {
            return new Account()
            {
                Id = id ?? new Account().Id,
                OpenId = Security.Sanitize(openId),
                FirstName = Security.Sanitize(firstName),
                LastName = Security.Sanitize(lastName),
                UserName = Security.Sanitize(username),
                Email = email.ToLower().Trim(),
                PasswordHash = password,
            };
        }
    }
}
