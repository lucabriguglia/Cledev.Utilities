public class Result3 : OneOfBase<Success, Failure>
{
    protected Result3(OneOf<Success, Failure> input) : base(input) { }

    public static implicit operator Result3(Success value) => new(value);
    public static implicit operator Result3(Failure value) => new(value);

    public bool IsSuccess => IsT0;
    public bool IsFailure => IsT1;

    public Success Success => AsT0;
    public Failure Failure => AsT1;

    public static Result3 Ok => new(new Success());
    public static Result3 WithFailure(string failureCode = FailureCodes.Error, string? title = null, string? description = null) => new(new Failure(failureCode, title, description));

    public bool TryPickSuccess(out Success success, out Failure failure) => TryPickT0(out success, out failure);
    public bool TryPickFailure(out Failure failure, out Success success) => TryPickT1(out failure, out success);
}

public class Result3<TResult> : OneOfBase<Success<TResult>, Failure>
{
    protected Result3(OneOf<Success<TResult>, Failure> input) : base(input) { }

    public static implicit operator Result3<TResult>(Success<TResult> value) => new(value);
    public static implicit operator Result3<TResult>(Failure value) => new(value);

    public bool IsSuccess => IsT0;
    public bool IsFailure => IsT1;

    public new TResult Value => AsT0.Value;
    public Failure Failure => AsT1;

    public static Result3<TResult> Ok(TResult value) => new(new Success<TResult>(value));
    public static Result3 WithFailure(string failureCode = FailureCodes.Error, string? title = null, string? description = null) => new(new Failure(failureCode, title, description));

    public bool TryPickSuccess(out Success<TResult> success, out Failure failure) => TryPickT0(out success, out failure);
    public bool TryPickFailure(out Failure failure, out Success<TResult> success) => TryPickT1(out failure, out success);
}
