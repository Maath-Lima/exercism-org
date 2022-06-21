using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] {0, 2, 5, 3, 7, 8, 4};

    public int Today() => birdsPerDay[birdsPerDay.Length - 1];

    public void IncrementTodaysCount()
    {
      birdsPerDay.SetValue(this.Today() + 1, birdsPerDay.Length - 1);  
    }

    public bool HasDayWithoutBirds() => Array.IndexOf(birdsPerDay, 0) != -1 ? true : false;

    public int CountForFirstDays(int numberOfDays)
    {   
        var total = 0;

        for (int i = 0; i < numberOfDays; i++)
        {
            total += birdsPerDay[i];
        }

        return total;
    }

    public int BusyDays()
    {
        var total = 0;

        foreach (var item in birdsPerDay)
        {
          if (item >= 5)
            total++;  
        }

        return total;
    }
}
