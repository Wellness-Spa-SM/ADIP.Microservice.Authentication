using Authentication.Domain.Helpers.CodesTable;
using Authentication.Infrastructure.Contexts;
using TM.Common.Utils;
using RoleEntity = Authentication.Domain.Models.Entities.CodesTable.Role;

namespace Authentication.Infrastructure.Repositories
{
    public class RoleSeederRepository(AuthenticationDbContext dbContext) :
        Seeder<AuthenticationDbContext, RoleEntity, string>
        (data, dbContext, d => d.NormalizedName!)
    {
        private static IList<RoleEntity> data =
        [
            RoleHelper.Create(id: "ROL425da9381a0249d2872631bfb548cfd4", name: "Customer"),
            RoleHelper.Create(id: "ROL8aa9a4824fbc45d7be6b3d5a2c4b9fc4", name: "Insurance Agent"),
            RoleHelper.Create(id: "ROL11f5be822aea42088b69faad9f2d4c5b", name: "Underwriter"),
            RoleHelper.Create(id: "ROL1bc41cba67d44933923f4a4a3e2a380c", name: "Senior Underwriter"),
            RoleHelper.Create(id: "ROLbc814d8a30b640d28380ad59b1efdf15", name: "Claims Adjuster"),
            RoleHelper.Create(id: "ROLf4a89483af17419994685b8e227117d5", name: "Claims Manager"),
            RoleHelper.Create(id: "ROLdbe62609ed0b4ae0ad3a51511d939888", name: "Customer Service"),
            RoleHelper.Create(id: "ROLe324596d4fea49ff954e8ee99b3de513", name: "Finance Officer"),
            RoleHelper.Create(id: "ROLdda4e3b69ae34ad7ae5a4b57e9224b7c", name: "Compliance Officer"),
            RoleHelper.Create(id: "ROL478eb359813c46bc9f4b5a6d20adfc8a", name: "Auditor"),
            RoleHelper.Create(id: "ROL5296752522ab4ee99750884ed81ef066", name: "Admin"),
        ];
    }
}
