using Microsoft.AspNetCore.Identity;
using System;
using TM.Common.Utils;

namespace Authentication.Domain.Models.Entities
{
    public class Account : IdentityUser
    {
        public Account() => base.Id = Security.GenerateExtendedGuid("ACC", 2);

        public string SecurityHash { get; set; } = Security.GenerateExtendedGuid("", 2);
        public string OpenId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
