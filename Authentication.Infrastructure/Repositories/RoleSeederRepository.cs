using Authentication.Common.Constants.Enums;
using Authentication.Infrastructure.Contexts;
using Authentication.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using TM.Common.Utils;
using RoleEntity = Authentication.Domain.Models.Entities.CodesTable.Role;

namespace Authentication.Infrastructure.Repositories
{
    public class RoleSeederRepository(
        AuthenticationDbContext dbContext,
        RoleManager<RoleEntity> roleManager) :
        Seeder<AuthenticationDbContext, RoleEntity, string>
        (data, dbContext, d => d.Id!, callBackAsync: roles => CreateRoleAsync(roleManager, roles))
    {
        private static IList<RoleEntity> data =
        [
            RoleHelper.Create(id: "ROL425da9381a0249d2872631bfb548cfd4", name: "Customer", roleType: RoleType.Customer),
            RoleHelper.Create(id: "ROL8aa9a4824fbc45d7be6b3d5a2c4b9fc4", name: "Insurance Agent", roleType: RoleType.InsuranceAgent),
            RoleHelper.Create(id: "ROL11f5be822aea42088b69faad9f2d4c5b", name: "Underwriter", roleType: RoleType.Underwriter),
            RoleHelper.Create(id: "ROL1bc41cba67d44933923f4a4a3e2a380c", name: "Senior Underwriter", roleType: RoleType.SeniorUnderwriter),
            RoleHelper.Create(id: "ROLbc814d8a30b640d28380ad59b1efdf15", name: "Claims Adjuster", roleType: RoleType.ClaimsAdjuster),
            RoleHelper.Create(id: "ROLf4a89483af17419994685b8e227117d5", name: "Claims Manager", roleType: RoleType.ClaimsManager),
            RoleHelper.Create(id: "ROLdbe62609ed0b4ae0ad3a51511d939888", name: "Customer Service", roleType: RoleType.CustomerService),
            RoleHelper.Create(id: "ROLe324596d4fea49ff954e8ee99b3de513", name: "Finance Officer", roleType: RoleType.FinanceOfficer),
            RoleHelper.Create(id: "ROLdda4e3b69ae34ad7ae5a4b57e9224b7c", name: "Compliance Officer", roleType: RoleType.ComplianceOfficer),
            RoleHelper.Create(id: "ROL478eb359813c46bc9f4b5a6d20adfc8a", name: "Auditor", roleType: RoleType.Auditor),
            RoleHelper.Create(id: "ROL5296752522ab4ee99750884ed81ef066", name: "Admin", roleType: RoleType.Admin),
        ];

        private static async Task CreateRoleAsync(RoleManager<RoleEntity> roleManager, IReadOnlyList<RoleEntity> roles)
        {
            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role.Name);
                if (roleExist)
                    continue;

                var result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                    continue;
            }
        }
    }
}
