namespace Naruto_Universe.Util;

public sealed record Error(int statusCode, string Code, string Message)
{
    public static readonly Error None = new Error(500, "None", string.Empty);
}

public class Result<TValue>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public TValue Value { get; }
    public Error Error { get; }

    private Result(bool isSuccess, TValue value, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid Error State", nameof(error));
        }

        Value = value;
        IsSuccess  = isSuccess;
        Error = error;
    }

    public static Result<TValue> Success(TValue value) => new(true, value, Error.None);
    public static Result<TValue> Failure(Error error) => new (false, default, error);

    public static implicit operator Result<TValue>(TValue value) => Success(value);
    public static implicit operator Result<TValue>(Error error)  => Failure(error);
}