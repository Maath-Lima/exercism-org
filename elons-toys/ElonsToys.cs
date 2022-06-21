using System;

class RemoteControlCar
{
    private int Battery { get; set; } = 100;
    private int Meters { get; set; } = 0;

    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {Meters} meters";

    public string BatteryDisplay() => $"Battery {(Battery != 0 ? $"at {Battery}%" : "empty")}";

    public void Drive()
    {
        if (Battery != 0)
        {
            Battery -= 1;
            Meters += 20; 
        }
    }
}
