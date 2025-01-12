namespace EFMigrations.Entities;

public sealed record Course
{
    public int Id { get; init; } = 0;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public int Duration { get; init; }
    public int Fee { get; init; }
}
