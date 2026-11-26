using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Common
{
    public class Utils
    {
        public static string NormalizeString(string value) => value.Trim().ToLower();
    }
}
