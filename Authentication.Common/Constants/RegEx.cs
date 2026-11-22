using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
namespace Authentication.Common.Constants
{
    public static class RegEx
    {
        public static class Password
        {
            public const int MIN_LENGTH = 8;
            public const int MAX_LENGTH = 200;
            public const int MAX_UNIQUE_CHARS = 1;

            /// <summary>
            /// Regular expression used to validate account passwords.
            /// </summary>
            /// <remarks>
            /// A valid password must:
            /// <list type="bullet">
            ///     <item>Contain between 8 and 200 characters.</item>
            ///     <item>Contain at least one uppercase letter (A-Z).</item>
            ///     <item>Contain at least one lowercase letter (a-z).</item>
            ///     <item>Contain at least one numeric digit (0-9).</item>
            ///     <item>Contain at least one special character.</item>
            ///     <item>Not contain whitespace characters.</item>
            /// </list>
            /// Use this pattern whenever validating an account password to ensure
            /// password requirements remain consistent across the application.
            /// 
            /// NOTE: If you want to change the Min and Max length properties, you must also change the MinLength and MaxLength of the pattern. 
            /// This is to ensure that the pattern is always in sync with the Min and Max length properties. 
            /// Reason: Because the 
            /// </remarks>
            [StringSyntax(StringSyntaxAttribute.Regex)]
            public const string PATTERN = @"^(?=.{8,200}$)(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^A-Za-z0-9\s])\S+$";
        }

        public static class Name
        {
            public const int MIN_LENGTH = 2;
            public const int MAX_LENGTH = 200;
        }


        public static class Guid
        {
            public const int MIN_LENGTH = 300;
            public const int MAX_LENGTH = 900;
        }
    }
}
