using System;

namespace FactoryMind.Template.Data.Entities
{
    [Flags]
    public enum UserRole
    {
        Admin = 4,
        Superuser = 2,
        User = 0
    }
}