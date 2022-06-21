using System;

public class Player
{
    public int RollDie() => new Random().Next(1, 18);

    public double GenerateSpellStrength() => Math.Round((new Random().NextDouble() * 10), 1);
}
