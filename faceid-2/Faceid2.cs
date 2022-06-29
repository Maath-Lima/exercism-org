using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object obj)
    {
        var evaluetadObj = obj as FacialFeatures;

        if (evaluetadObj is null || !GetType().Equals(evaluetadObj.GetType()))
        {
            return false;
        }

        return EyeColor.Equals(evaluetadObj.EyeColor) &&
               PhiltrumWidth == evaluetadObj.PhiltrumWidth;
    }

    public override int GetHashCode() => EyeColor.GetHashCode() + PhiltrumWidth.GetHashCode();
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    private const string EMAIL_ADMIN = "admin@exerc.ism";
    private const string EYECOLOR_ADMIN = "green";
    private const decimal PHILTRUMWIDTH_ADMIN = 0.9m;

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public bool AdminEquals() => Equals(new Identity(EMAIL_ADMIN, 
                                        new FacialFeatures(EYECOLOR_ADMIN, PHILTRUMWIDTH_ADMIN)));

    public override bool Equals(object obj)
    {
        var evaluetadObj = obj as Identity;

        if (evaluetadObj is null || !GetType().Equals(evaluetadObj.GetType()))
        {
            return false;
        }

        return Email.Equals(evaluetadObj.Email) && FacialFeatures.Equals(evaluetadObj.FacialFeatures);
    }

    public override int GetHashCode() => Email.GetHashCode() + FacialFeatures.GetHashCode();
}

public class Authenticator
{
    private HashSet<Identity> RegisteredIdentities;

    public Authenticator()
    {
        RegisteredIdentities = new HashSet<Identity>();
    }

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.AdminEquals();
 
    public bool Register(Identity identity) => RegisteredIdentities.Add(identity);
   
    public bool IsRegistered(Identity identity) => RegisteredIdentities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA, identityB);
}
