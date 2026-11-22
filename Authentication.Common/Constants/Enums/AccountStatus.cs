using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Common.Constants.Enums
{
    public enum AccountStatus
    {
        PendingVerification = 1,
        Active = 2,
        Locked = 3,
        Suspended = 4,
        Disabled = 5
    }
}
