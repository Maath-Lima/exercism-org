using System;

// TODO: define the 'AccountType' enum
public enum AccountType
{
    Guest = Permission.Read,
    User = (Permission.Read | Permission.Write),
    Moderator = (Permission.Read | Permission.Write | Permission.Delete)
}

// TODO: define the 'Permission' enum
[Flags]
public enum Permission
{
    None = 0,
    Read = 1,
    Write = 2,
    Delete = 4,
    All = Read | Write | Delete
}

static class Permissions
{
    public static Permission Default(AccountType accountType) => Enum.IsDefined(typeof(AccountType), accountType) ? (Permission)accountType : Permission.None;

    public static Permission Grant(Permission current, Permission grant) => current | grant;

    public static Permission Revoke(Permission current, Permission revoke) => current & (~revoke);

    public static bool Check(Permission current, Permission check) => (current & check) == check;
}
