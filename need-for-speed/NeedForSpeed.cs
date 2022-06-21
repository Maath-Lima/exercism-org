using System;

class RemoteControlCar
{
    public int Speed { get; set; }
    public int BatteryDrain { get; set; }
    public int Battery { get; set; }
    public int Distance { get; set; }

    // TODO: define the constructor for the 'RemoteControlCar' class
    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.Speed = speed;
        this.BatteryDrain = batteryDrain;
        this.Battery = 100;
        this.Distance = 0;
    }

    public bool BatteryDrained() => this.Battery < this.BatteryDrain;

    public int DistanceDriven() => this.Distance;
    
    public void Drive()
    {
        if (!this.BatteryDrained())
        {
            this.Distance += this.Speed;
            this.Battery -= this.BatteryDrain;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    public int Distance { get; set; }

    // TODO: define the constructor for the 'RaceTrack' class
    public RaceTrack(int distance)
    {
        this.Distance = distance;
    }

    public bool CarCanFinish(RemoteControlCar car) => this.Distance <= (car.Speed * ( car.Battery / car.BatteryDrain ));
}
