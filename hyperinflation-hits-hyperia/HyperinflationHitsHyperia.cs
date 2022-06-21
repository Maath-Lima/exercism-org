using System;

public static class CentralBank
{
    private const string ERROR_MESSAGE = "*** Too Big ***";
    private const string DECIMAL_ERROR_MESSAGE = "*** Much Too Big ***";

    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            checked
            {
                return (@base * multiplier).ToString();
            }
        }
        catch (OverflowException)
        {
            return ERROR_MESSAGE;
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float result = @base * multiplier;

        return (result == float.PositiveInfinity || result == float.NegativeInfinity) ? ERROR_MESSAGE : result.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            checked
            {
                return (salaryBase * multiplier).ToString();
            }
        }
        catch (OverflowException)
        {
            return DECIMAL_ERROR_MESSAGE;
        }
    }
}
