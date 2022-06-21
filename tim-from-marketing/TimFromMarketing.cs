using System;

static class Badge
{
    private const string OWNER_BADGE = "OWNER";
    private const string DASH_STRING = " - ";

    public static string Print(int? id, string name, string? department)
    {   
        var employeeId = !(id is null) ? $"[{id.ToString()}]{DASH_STRING}" : string.Empty;
        var departmentName = !(department is null) ? $"{DASH_STRING}{department.ToUpper()}" 
                                                     : $"{DASH_STRING}{OWNER_BADGE}";

        return $"{employeeId}{name}{departmentName}";
    }
}
