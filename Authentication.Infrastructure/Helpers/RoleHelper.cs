using Authentication.Common.Constants;
using Authentication.Common.Constants.Enums;
using Authentication.Domain.Models.Entities.CodesTable;

namespace Authentication.Infrastructure.Helpers
{
    public static class RoleHelper
    {
        public static Role Create(
            string name,
            RoleType roleType,
            string? id = null,
            string creator = StaticDetail.DOMAIN_SYSTEM,
            int priority = StaticDetail.PRIORITY_DEFAULT
        )
        {
            return new Role
            {
                Name = name,
                Id = id ?? Guid.NewGuid().ToString(),
                CreatedBy = creator,
                DateTimeCreated = DateTime.Now,
                ModifiedBy = creator,
                DateTimeModified = DateTime.Now,
                IsActive = true,
                RoleType = roleType
            };
        }
    }
}
