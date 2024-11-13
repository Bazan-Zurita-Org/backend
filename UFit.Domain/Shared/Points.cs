namespace UFit.Domain.Shared;

public sealed record Points(int Value)
{
    public static Points operator +(Points first, Points second) => new(first.Value + second.Value); 
}