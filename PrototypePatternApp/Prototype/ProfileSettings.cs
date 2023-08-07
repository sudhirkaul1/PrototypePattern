namespace PrototypePatternApp.Prototype;

public class ProfileSettings
{
    public bool IsPrivate { get; internal set; }
    public bool HideEmail { get; internal set; }
    public bool HideAge { get; internal set; }

    public ProfileSettings Clone()
    {
        return new ProfileSettings()
        {
            IsPrivate = IsPrivate,
            HideEmail = HideEmail,
            HideAge = HideAge
        };
    }
}