using Authentication.Common.Constants.Enums;
using Authentication.Domain.Models.Entities;
using Authentication.Domain.Models.Entities.CodesTable;
using Authentication.Infrastructure.Contexts;
using Authentication.Infrastructure.Helpers;
using Authentication.Infrastructure.Models.Complex;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TM.Common.Utils;

namespace Authentication.Infrastructure.Repositories
{
    public class AccountSeederRepository(
        AuthenticationDbContext dbContext, 
        UserManager<Account> userManager) :
        Seeder<AuthenticationDbContext, Account, string>
        (accounts, dbContext, x => x.Id, callBackAsync: acc => CreateAccountAsync(dbContext, userManager, acc))
    {
        private static IList<Account> accounts =
        [
            AccountHelper.CreateAccount(
                "OID1", 
                "Underwriter 1", 
                "Sample",
                "underwriter_sample1",
                "underwriter_sample1@gmail.com",
                "Abc123!-K3njIe",
                "ACCacdf3b1656224c60aedd4379ac2c482e6e8a08dc4ea14cafaa6da5cdb223afaf"),

            AccountHelper.CreateAccount(
                "OID2",
                "SeniorUnderwriter 1",
                "Sample",
                "seniorunderwriter_sample1",
                "seniorunderwriter_sample1@gmail.com",
                "Abc123!-K3njIe",
                "ACCd86e730806bc4de2bc5c6837c501b560bad8b8b978a243ee97d68ddbb9a8d348"),

            AccountHelper.CreateAccount(
                "OID3",
                "Customer 1",
                "Sample",
                "customer_sample1",
                "customer_sample1@gmail.com",
                "Abc123!-K3njIe",
                "ACCd48804018193470f997e7dbc6661668dcd396922f6d3480a9a8f1b84c6ae77c2"),

            AccountHelper.CreateAccount(
                "OID4",
                "Auditor 1",
                "Sample",
                "auditor_sample1",
                "auditor_sample1@gmail.com",
                "Abc123!-K3njIe",
                "ACC145daf437e9e4eb88112afa73715eb63fcbe3e751edb4eb987bfa8689c46da61"),

            AccountHelper.CreateAccount(
                "OID5",
                "Admin 1",
                "Sample",
                "admin_sample2",
                "admin_sample2@gmail.com",
                "Abc123!-K3njIe",
                "ACC718908bff77a45c5b26b9eeb58085895b38711f2c3664e0284b5f935d26a59bb"),

            AccountHelper.CreateAccount(
                "OID6",
                "InsuranceAgent 1",
                "Sample",
                "insuranceagent_sample2",
                "insuranceagent_sample2@gmail.com",
                "Abc123!-K3njIe",
                "ACCc6653b8a153948d9b1c444cd5f936f4f075faebb46d247ebbf82a50361d65bba"),

            AccountHelper.CreateAccount(
                "OID7",
                "ClaimsAdjuster 1",
                "Sample",
                "claimsadjuster_sample2",
                "claimsadjuster_sample2@gmail.com",
                "Abc123!-K3njIe",
                "ACCb064fd32a5c142be9b5f1ee6930ab60f148123eab7544589bd633f26ff5ec3a5"),

            AccountHelper.CreateAccount(
                "OID2222",
                "CustomerService 1",
                "Sample",
                "customerservice_sample2",
                "customerservice_sample2@gmail.com",
                "Abc123!-K3njIe",
                "ACCe375ae1701bc4cca8c38e5330ac17e883ecf6c33e1f249c0bbbb40c1adceff6d"),

            AccountHelper.CreateAccount(
                "OID2222",
                "ComplianceOfficer 1",
                "Sample",
                "complianceofficer_sample2",
                "complianceofficer_sample2@gmail.com",
                "Abc123!-K3njIe",
                "ACCce67eca2d0fe485faae290a90649ce8fccdb60681484497790fcbd5e8232a5d8"),

            AccountHelper.CreateAccount(
                "OID2222",
                "FinanceOfficer 1",
                "Sample",
                "financeofficer_sample2",
                "financeofficer_sample2@gmail.com",
                "Abc123!-K3njIe",
                "ACCe7c38d245a584c188d9e5d26090e43169a76a11180c24668a73f4e668deebaa1"),

            AccountHelper.CreateAccount(
                "OID2222",
                "ClaimsManager 1",
                "Sample",
                "claimsmanager_sample2",
                "claimsmanager_sample2@gmail.com",
                "Abc123!-K3njIe",
                "ACC46afdff1f2fe44088ac7fede8c5fcd79cfdab0963a2d4e6e88800d591db5d1d5"),
        ];

        private static IList<AccountRole> accountRoles =
        [
            new AccountRole(RoleType.Underwriter, accounts.ElementAt(0).Id),
            new AccountRole(RoleType.SeniorUnderwriter, accounts.ElementAt(1).Id),
            new AccountRole(RoleType.Customer, accounts.ElementAt(2).Id),
            new AccountRole(RoleType.Auditor, accounts.ElementAt(3).Id),
            new AccountRole(RoleType.Admin, accounts.ElementAt(4).Id),
            new AccountRole(RoleType.InsuranceAgent, accounts.ElementAt(5).Id),
            new AccountRole(RoleType.ClaimsAdjuster, accounts.ElementAt(6).Id),
            new AccountRole(RoleType.CustomerService, accounts.ElementAt(7).Id),
            new AccountRole(RoleType.ComplianceOfficer, accounts.ElementAt(8).Id),
            new AccountRole(RoleType.FinanceOfficer, accounts.ElementAt(9).Id),
            new AccountRole(RoleType.ClaimsManager, accounts.ElementAt(10).Id),
        ];

        private static async Task CreateAccountAsync(
            AuthenticationDbContext authenticationDbContext,
            UserManager<Account> userManager, 
            IReadOnlyList<Account> accounts)
        {
            var dbRoles = await authenticationDbContext.Roles.Untracked.ToListAsync();
            var joinedRoles = dbRoles.Join(accountRoles, 
                rt => rt.RoleType, 
                ar => ar.RoleType,
                (rt, ar) => new
                {
                    AccountId = ar.AccountId,
                    RoleName = rt.Name,
                    RoleType = ar.RoleType
                });

            foreach (var _data in accounts)
            {
                string roleName = joinedRoles.First(x => x.AccountId == _data.Id).RoleName!;
                await userManager.CreateAsync(_data, _data.PasswordHash!);
                await userManager.AddToRoleAsync(_data, roleName);
            }
        }
    }
}
