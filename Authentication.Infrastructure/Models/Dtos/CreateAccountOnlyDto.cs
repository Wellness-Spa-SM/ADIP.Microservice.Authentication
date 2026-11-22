using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Authentication.Common.Constants;

namespace Authentication.Infrastructure.Models.Dtos
{
    public class CreateAccountOnlyDto
    {
        [Required, EmailAddress] public string Email { get; set; }
        [Required, RegularExpression(RegEx.Password.PATTERN)] public string Password { get; set; }
        [Required, StringLength(RegEx.Name.MAX_LENGTH, MinimumLength = RegEx.Name.MIN_LENGTH)] public string FirstName { get; set; }
        [Required, StringLength(RegEx.Name.MAX_LENGTH, MinimumLength = RegEx.Name.MIN_LENGTH)] public string LastName { get; set; }
    }
}
