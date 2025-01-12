namespace EFMigrations.Entities;

public sealed record Grade
{
    public int Id { get; init; } = 0;
    public int StudentId { get; init; } = 0;
    public int CourseId { get; init; } = 0;
    public int Mark { get; init; } = 0;
}