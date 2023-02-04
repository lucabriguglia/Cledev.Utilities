﻿namespace Cledev.OpenAI.Results;

public record Success;

public record Success<TResult>
{
    public TResult? Result { get; init; }

    public Success()
    {
    }
    
    public Success(TResult result)
    {
        Result = result;
    }
}
