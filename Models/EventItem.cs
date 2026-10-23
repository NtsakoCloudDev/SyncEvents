namespace MyBlazorApp.Models;

public sealed class EventItem
{
    private readonly List<EventAttendee> _attendees = [];

    public required int Id { get; init; }
    public required string Title { get; init; }
    public required string Category { get; init; }
    public required string Venue { get; init; }
    public required string Description { get; init; }
    public required DateTimeOffset StartsAt { get; init; }
    public required int Capacity { get; init; }
    public int RegisteredCount => _attendees.Count;
    public int AvailableSeats => Math.Max(0, Capacity - RegisteredCount);
    public bool IsFull => AvailableSeats == 0;
    public IReadOnlyList<EventAttendee> Attendees => _attendees;

    internal void AddAttendee(EventAttendee attendee) => _attendees.Add(attendee);
}

public sealed record EventAttendee(string Name, string Email);