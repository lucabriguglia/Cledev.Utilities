//using Cledev.Core.Events;
//using OneOf;

//namespace Cledev.Core.Results;

//public class Result2 : OneOfBase<Success, Failure>
//{
//    protected Result2(OneOf<Success, Failure> input) : base(input) { }

//    public static implicit operator Result2(Success value) => new(value);
//    public static implicit operator Result2(Failure value) => new(value);

//    public bool IsSuccess => IsT0;
//    public bool IsFailure => IsT1;

//    public Success Success => AsT0;
//    public Failure Failure => AsT1;

//    public static Result2 Ok(params IEvent[] events) => new(new Success(events));
//    public static Result2 Fail(string failureCode = ErrorCodes.Error, string? title = null, string? description = null) => new(new Failure(failureCode, title, description));

//    public bool TryPickSuccess(out Success success, out Failure failure) => TryPickT0(out success, out failure);
//    public bool TryPickFailure(out Failure failure, out Success success) => TryPickT1(out failure, out success);
//}

//public class Result2<TResult> : OneOfBase<TResult, Failure>
//{
//    protected Result2(OneOf<TResult, Failure> input) : base(input) { }

//    public static implicit operator Result2<TResult>(TResult value) => new(value);
//    public static implicit operator Result2<TResult>(Failure value) => new(value);

//    public bool IsSuccess => IsT0;
//    public bool IsFailure => IsT1;

//    public new TResult Value => AsT0;
//    public Failure Failure => AsT1;

//    public static Result2<TResult> Ok(TResult value) => new(value);
//    public static Result2<TResult> Fail(string failureCode = ErrorCodes.Error, string? title = null, string? description = null) => new(new Failure(failureCode, title, description));

//    public bool TryPickSuccess(out TResult result, out Failure failure) => TryPickT0(out result, out failure);
//    public bool TryPickFailure(out Failure failure, out TResult result) => TryPickT1(out failure, out result);
//}