using System;
using System.Collections.Generic;

public class Authenticator
{
    // TODO: Implement the Authenticator.Admin property
    public Identity Admin { get; }

    // TODO: Implement the Authenticator.Developers property
    public IDictionary<string, Identity> Developers { get; }

    public Authenticator()
    {
        Admin = GetNewIdentity("admin@ex.ism", "green", 0.9m, new List<string>() { "Chanakya", "Mumbai", "India" });

        Developers = new Dictionary<string, Identity>() { { "Bertrand",
                                                            GetNewIdentity("bert@ex.ism", "blue", 0.8m,
                                                                            new List<string> { "Bertrand", "Paris", "France" })
                                                           },
                                                           { "Anders",
                                                            GetNewIdentity("anders@ex.ism", "brown", 0.85m,
                                                                            new List<string> { "Anders", "Redmond", "USA" })
                                                           }
                                                        };
    }

    private Identity GetNewIdentity(string email, string eyeColor, decimal philtrumWidth, IList<string> nameAndAddress) => new Identity()
    {
        Email = email,
        FacialFeatures = new FacialFeatures() { EyeColor = eyeColor, PhiltrumWidth = philtrumWidth },
        NameAndAddress = nameAndAddress
    };
}

//**** please do not modify the FacialFeatures class ****
public class FacialFeatures
{
    public string EyeColor { get; set; }
    public decimal PhiltrumWidth { get; set; }
}

//**** please do not modify the Identity class ****
public class Identity
{
    public string Email { get; set; }
    public FacialFeatures FacialFeatures { get; set; }
    public IList<string> NameAndAddress { get; set; }
}
