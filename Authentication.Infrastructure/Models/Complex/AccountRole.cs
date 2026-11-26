using Authentication.Common.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Infrastructure.Models.Complex
{
    public record AccountRole(RoleType RoleType, string AccountId)
    {
    }
}
