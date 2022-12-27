﻿namespace Cledev.Core.Utilities.Async;

/// <summary>
/// Helper class to run async methods within a sync process.
/// https://www.ryadel.com/en/asyncutil-c-helper-class-async-method-sync-result-wait/
/// </summary>
public static class AsyncExtensions
{
    private static readonly TaskFactory TaskFactory = new
            (CancellationToken.None,
            TaskCreationOptions.None,
            TaskContinuationOptions.None,
            TaskScheduler.Default);

    /// <summary>
    /// Executes an async Task method which has a void return value synchronously
    /// USAGE: AsyncUtil.RunSync(() => AsyncMethod());
    /// </summary>
    /// <param name="task">Task method to execute</param>
    public static void RunSync(this Task task)
        => TaskFactory
            .StartNew(() => task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();

    /// <summary>
    /// Executes an async Task<T> method which has a T return type synchronously
    /// USAGE: T result = AsyncUtil.RunSync(() => AsyncMethod<T>());
    /// </summary>
    /// <typeparam name="TResult">Return Type</typeparam>
    /// <param name="task">Task<T> method to execute</param>
    /// <returns></returns>
    public static TResult RunSync<TResult>(this Task<TResult> task)
        => TaskFactory
            .StartNew(() => task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
}