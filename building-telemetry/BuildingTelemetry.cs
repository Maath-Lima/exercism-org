using System;

public class RemoteControlCar
{
    private int batteryPercentage = DEFAULT_BATTERY;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    private const int LESS_SERIAL_NUMBER_VALUES = -1;
    private const int DEFAULT_BATTERY = 100;

    public int BatteryUsage
    {
        get
        {
            return DEFAULT_BATTERY - batteryPercentage;
        }
    }
    
    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors) => this.sponsors = sponsors;

    public string DisplaySponsor(int sponsorNum) => sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum < latestSerialNum)
        {
            serialNum = latestSerialNum;
            batteryPercentage = LESS_SERIAL_NUMBER_VALUES;
            distanceDrivenInMeters = LESS_SERIAL_NUMBER_VALUES;

            return false;
        }

        latestSerialNum = serialNum;

        batteryPercentage = this.batteryPercentage;
        distanceDrivenInMeters = this.distanceDrivenInMeters;

        return true;
    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        if (!(car.GetTelemetryData(ref serialNum, out int batteryPercentage, out int distanceDrivenInMeters) && distanceDrivenInMeters > 0))
        {
            return "no data";
        }

        return $"usage-per-meter={car.BatteryUsage / distanceDrivenInMeters}";
    }
}
