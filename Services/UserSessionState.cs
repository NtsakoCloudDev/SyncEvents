namespace MyBlazorApp.Services;

public sealed class UserSessionState
{
    public string? LastAttendeeName { get; private set; }

    public void RememberAttendee(string name) => LastAttendeeName = name.Trim();
}