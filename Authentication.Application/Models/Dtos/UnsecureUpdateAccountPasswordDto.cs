using Authentication.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Authentication.Application.Models.Dtos
{
    public class UnsecureUpdateAccountPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(RegEx.Password.PATTERN)]
        public string NewPassword { get; set; }
    }
}
