using OneOf;

namespace Cledev.Core.Results;

public class Result : OneOfBase<Success, Failure>
{
    protected Result(OneOf<Success, Failure> input) : base(input) { }

    public static implicit operator Result(Success value) => new(value);
    public static implicit operator Result(Failure value) => new(value);

    public bool IsSuccessResult => IsT0;
    public bool IsFailureResult => IsT1;

    public bool IsSuccess(out Success success, out Failure failure) => TryPickT0(out success, out failure);
    public bool IsFailure(out Failure failure, out Success success) => TryPickT1(out failure, out success);
}

public class Result<TResult> : OneOfBase<TResult, Failure>
{
    protected Result(OneOf<TResult, Failure> input) : base(input) { }

    public static implicit operator Result<TResult>(TResult value) => new(value);
    public static implicit operator Result<TResult>(Failure value) => new(value);

    public bool IsSuccessResult => IsT0;
    public bool IsFailureResult => IsT1;

    public bool IsSuccess(out TResult result, out Failure failure) => TryPickT0(out result, out failure);
    public bool IsFailure(out Failure failure, out TResult result) => TryPickT1(out failure, out result);
}
