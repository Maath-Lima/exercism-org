using System;
using System.Globalization;

class WeighingMachine
{
    private const string FORMATER = "F";

    public readonly int Precision;

    private double _weight;
    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _weight = value;
        }
    }

    public string DisplayWeight
    {
        get
        {
            return $"{(_weight - TareAdjustment).ToString($"{FORMATER}{Precision}", CultureInfo.InvariantCulture)} kg";
        }
    }

    public double TareAdjustment { get; set; } = 5.0;

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}
