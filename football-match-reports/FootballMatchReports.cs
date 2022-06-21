using System;

public static class PlayersTypesConstants
{
    public const string GOALIE = "goalie";
    public const string LEFT_BACK = "left back";
    public const string CENTER_BACK = "center back";
    public const string RIGHT_BACK = "right back";
    public const string MIDFIELDER = "midfielder";
    public const string LEFT_WING = "left wing";
    public const string STRIKER = "striker";
    public const string RIGHT_WING = "right wing";
}

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return PlayersTypesConstants.GOALIE;
            case 2:
                return PlayersTypesConstants.LEFT_BACK;
            case 4:
            case 3:
                return PlayersTypesConstants.CENTER_BACK;
            case 5:
                return PlayersTypesConstants.RIGHT_BACK;
            case 6:
            case 7:
            case 8:
                return PlayersTypesConstants.MIDFIELDER;
            case 9:
                return PlayersTypesConstants.LEFT_WING;
            case 10:
                return PlayersTypesConstants.STRIKER;
            case 11:
                return PlayersTypesConstants.RIGHT_WING;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static string AnalyzeOffField(object report)
    {
        if (report is int)
        {
            return $"There are {report} supporters at the match.";
        }
        else if (report is string)
        {
            return report.ToString();
        }
        else if (report is Incident)
        {
            return ((Incident)report).GetDescription();
        }
        else if (report is Manager)
        {
            return ((Manager)report).ToString();
        }

        throw new ArgumentException();
    }
}
