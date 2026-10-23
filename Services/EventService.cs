using MyBlazorApp.Models;

namespace MyBlazorApp.Services;

public sealed class EventService
{
    private readonly List<EventItem> _events =
    [
        new EventItem
        {
            Id = 1,
            Title = "Saturday farmers market",
            Category = "Food",
            Venue = "Riverside Commons",
            Description = "Meet local growers, makers, and neighbours over a slow morning market.",
            StartsAt = DateTimeOffset.Now.Date.AddDays(4).AddHours(9),
            Capacity = 80
        },
        new EventItem
        {
            Id = 2,
            Title = "Open-air film night",
            Category = "Arts",
            Venue = "The Old Depot",
            Description = "A relaxed outdoor screening with food stalls and space to bring a blanket.",
            StartsAt = DateTimeOffset.Now.Date.AddDays(8).AddHours(18),
            Capacity = 120
        },
        new EventItem
        {
            Id = 3,
            Title = "Community garden morning",
            Category = "Community",
            Venue = "Hillview Garden",
            Description = "Spend a few hours planting, sharing practical tips, and enjoying a garden lunch.",
            StartsAt = DateTimeOffset.Now.Date.AddDays(12).AddHours(8),
            Capacity = 24
        },
        new EventItem
        {
            Id = 4,
            Title = "Live music on the square",
            Category = "Music",
            Venue = "Market Square",
            Description = "An easygoing evening of local bands, street food, and good company.",
            StartsAt = DateTimeOffset.Now.Date.AddDays(16).AddHours(17),
            Capacity = 100
        }
    ];

    public IReadOnlyList<EventItem> Events => _events;

    public IReadOnlyList<string> Categories =>
        ["All events", .. _events.Select(item => item.Category).Distinct().Order()];

    public bool TryRegister(int eventId, string name, string email, out string error)
    {
        var selectedEvent = _events.FirstOrDefault(item => item.Id == eventId);
        if (selectedEvent is null)
        {
            error = "That event is no longer available.";
            return false;
        }

        var normalizedEmail = email.Trim();
        if (selectedEvent.Attendees.Any(attendee =>
                string.Equals(attendee.Email, normalizedEmail, StringComparison.OrdinalIgnoreCase)))
        {
            error = "That email address is already registered for this event.";
            return false;
        }

        if (selectedEvent.IsFull)
        {
            error = "This event is full. Please choose another event.";
            return false;
        }

        selectedEvent.AddAttendee(new EventAttendee(name.Trim(), normalizedEmail));
        error = string.Empty;
        return true;
    }
}