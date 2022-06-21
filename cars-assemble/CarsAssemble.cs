using System;

static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        return  speed >= 1 && speed <= 4 ? 1 
                : speed >= 5 && speed <= 8 ? 0.9
                : speed == 9 ? 0.8
                : speed == 10 ? 0.77 : 0;
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        return (speed * 221) * AssemblyLine.SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)AssemblyLine.ProductionRatePerHour(speed) / 60;
    }
}
