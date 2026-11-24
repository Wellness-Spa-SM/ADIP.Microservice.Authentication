using Authentication.Common.Constants;
using Authentication.Domain.Models.Entities.CodesTable;

namespace Authentication.Domain.Helpers.CodesTable
{
    public static class RoleHelper
    {
        public static Role Create(
            string name,
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
            };
        }
    }
}
