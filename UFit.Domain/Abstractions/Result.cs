using System.Diagnostics.CodeAnalysis;

namespace UFit.Domain.Abstractions;
public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (error != Error.None && isSuccess || 
            error == Error.None && !isSuccess)
        {
            throw new InvalidOperationException("Invalid Operation");
        }
        IsSuccess = isSuccess;
        Error = error;
    }
    public Error Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
    public static Result<TValue> Create<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    [NotNull]
    public TValue? Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a faliure result cant not be accessed.");

    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}