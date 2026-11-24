using Authentication.Application.Models.Dtos;
using Authentication.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TM.Common.Utils;
namespace Authentication.Application.Helpers
{
    internal class AccountHelper
    {
        internal static Account ToAccount(CreateAccountDto data)
        {
            return new Account()
            {
                OpenId = Security.Sanitize(data.OpenId),
                FirstName = Security.Sanitize(data.FirstName),
                LastName = Security.Sanitize(data.LastName),
                UserName = Security.Sanitize(data.Username),
                Email = data.Email.ToLower().Trim(),
            };
        }
    }
}
