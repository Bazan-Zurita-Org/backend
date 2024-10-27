namespace UFit.Domain.Abstractions;
public sealed record Error(string Code, string Name)
{
    public readonly static Error None = new(string.Empty, string.Empty);
    public readonly static Error NullValue = new("Error.NullValue", "Null Value was provided");
}
