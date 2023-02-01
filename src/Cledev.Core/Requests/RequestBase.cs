namespace Cledev.Core.Requests;

public abstract class RequestBase : IRequest
{
}

public abstract record RequestBase<TResult> : IRequest<TResult>
{
}
