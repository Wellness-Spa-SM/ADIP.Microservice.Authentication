using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Authentication.Common.Constants;
using Authentication.Common.Constants.Enums;

namespace Authentication.Application.Models.Dtos
{
    public class CreateAccountDto
    {
        [Required]
        [EmailAddress] 
        public string Email { get; set; }

        [Required]
        [StringLength(RegEx.Name.MAX_LENGTH, MinimumLength = RegEx.Name.MIN_LENGTH)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(RegEx.Password.PATTERN)] 
        public string Password { get; set; }

        [Required]
        [StringLength(RegEx.Name.MAX_LENGTH, MinimumLength = RegEx.Name.MIN_LENGTH)] 
        public string FirstName { get; set; }

        [Required]
        [StringLength(RegEx.Name.MAX_LENGTH, MinimumLength = RegEx.Name.MIN_LENGTH)]
        public string LastName { get; set; }

        [Required]
        [StringLength(RegEx.Guid.MAX_LENGTH_1, MinimumLength = RegEx.Guid.MIN_LENGTH_1)] 
        public string OpenId { get; set; }

        [Required]
        public RoleType RoleType { get; set; }
    }
}
