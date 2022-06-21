using System;

abstract class Character
{
    public int Damage { get; set; }
    public string CharacterType { get; set; }
    protected Character(string characterType)
    {
        this.CharacterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {this.CharacterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    public bool IsSpeelPrepared { get; set; } = false;

    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target) => IsSpeelPrepared ? 12 : 3;

    public void PrepareSpell()
    {
        this.IsSpeelPrepared = true;
    }

    public override bool Vulnerable() => !IsSpeelPrepared;
}
