using System;

namespace Seac.WebDeleghe.Data.Entities
{
    [Flags]
    public enum UserRole
    {
        Admin = 4,
        Superuser = 2,
        User = 0
    }
}