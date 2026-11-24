using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Common.Constants;
using Tables = Authentication.Domain.Models.Entities.CodesTable;
using Types = Authentication.Common.Constants.Enums;

namespace Authentication.Domain.Helpers.CodesTable
{
    public class AccountStatusHelper
    {
        public static Tables.AccountStatus Create(
            Types.AccountStatus code,
            string title,
            Guid? id = null,
            string creator = StaticDetail.DOMAIN_SYSTEM,
            int priority = StaticDetail.PRIORITY_DEFAULT
        )
        {
            return new Tables.AccountStatus
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

        public static Tables.AccountStatus Create(
            Types.AccountStatus code,
            string title,
            string? id = null,
            string creator = StaticDetail.DOMAIN_SYSTEM,
            int priority = StaticDetail.PRIORITY_DEFAULT
        )
        {
            return Create(code, title, Guid.Parse(id), creator, priority);
        }
    }
}
