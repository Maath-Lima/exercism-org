using System;
using System.Collections.Generic;

public class SecurityPassMaker
{
    private const string NOT_STAFF_TITLE = "Too Important for a Security Pass";
    private const string PRIORITY_PERSONNEL = "Priority Personnel";

    public string GetDisplayName(TeamSupport support) => typeof(Staff).IsAssignableFrom(support.GetType()) ? CheckIfIsSecurityMember(support) : NOT_STAFF_TITLE;
    
    private string CheckIfIsSecurityMember(TeamSupport support)
    {
        if (typeof(Security).IsAssignableFrom(support.GetType())
               && support.GetType() == typeof(Security))
        {
            return $"{support.Title} {PRIORITY_PERSONNEL}";
        }

        return support.Title;
    }
}

/**** Please do not alter the code below ****/

public interface TeamSupport { string Title { get; } }

public abstract class Staff : TeamSupport { public abstract string Title { get; } }

public class Manager : TeamSupport { public string Title { get; } = "The Manager"; }

public class Chairman : TeamSupport { public string Title { get; } = "The Chairman"; }

public class Physio : Staff { public override string Title { get; } = "The Physio"; }

public class OffensiveCoach : Staff { public override string Title { get; } = "Offensive Coach"; }

public class GoalKeepingCoach : Staff { public override string Title { get; } = "Goal Keeping Coach"; }

public class Security : Staff { public override string Title { get; } = "Security Team Member"; }

public class SecurityJunior : Security { public override string Title { get; } = "Security Junior"; }

public class SecurityIntern : Security { public override string Title { get; } = "Security Intern"; }

public class PoliceLiaison : Security { public override string Title { get; } = "Police Liaison Officer"; }
