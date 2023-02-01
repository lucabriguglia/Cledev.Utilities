using System.Linq.Expressions;
using System.Reflection;

namespace Cledev.Core.Utilities.Queries;

/// <summary>
/// https://stackoverflow.com/questions/34906437/how-to-construct-order-by-expression-dynamically-in-entity-framework
/// </summary>
public static class RequestExtensions
{
    public static IRequestable<T> OrderBy<T>(this IRequestable<T> source, RequestOptions options)
    {
        var propertyName = options.OrderByField;
        var direction = options.OrderByDirection;

        if (!string.IsNullOrWhiteSpace(propertyName) && direction != null && source.PropertyExists(propertyName))
        {
            source = direction == OrderByDirectionType.Asc
                ? source.OrderByProperty(propertyName)
                : source.OrderByPropertyDescending(propertyName);
        };

        return source;
    }

    private static readonly MethodInfo OrderByMethod =
        typeof(Requestable).GetMethods().Single(method =>
            method.Name == "OrderBy" && method.GetParameters().Length == 2);

    private static readonly MethodInfo OrderByDescendingMethod =
        typeof(Requestable).GetMethods().Single(method =>
            method.Name == "OrderByDescending" && method.GetParameters().Length == 2);

    private static bool PropertyExists<T>(this IRequestable<T> source, string propertyName)
    {
        return typeof(T).GetProperty(propertyName,
            BindingFlags.IgnoreCase |
            BindingFlags.Public |
            BindingFlags.Instance) is not null;
    }

    private static IRequestable<T> OrderByProperty<T>(this IRequestable<T> source, string propertyName)
    {
        if (typeof(T).GetProperty(propertyName,
                BindingFlags.IgnoreCase |
                BindingFlags.Public |
                BindingFlags.Instance) is null)
        {
            return null;
        }

        ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
        Expression orderByProperty = Expression.Property(parameterExpression, propertyName);
        LambdaExpression lambda = Expression.Lambda(orderByProperty, parameterExpression);
        MethodInfo genericMethod = OrderByMethod.MakeGenericMethod(typeof(T), orderByProperty.Type);
        object ret = genericMethod.Invoke(null, new object[] { source, lambda });
        return (IRequestable<T>)ret;
    }

    private static IRequestable<T> OrderByPropertyDescending<T>(this IRequestable<T> source, string propertyName)
    {
        if (typeof(T).GetProperty(propertyName,
                BindingFlags.IgnoreCase |
                BindingFlags.Public |
                BindingFlags.Instance) is null)
        {
            return null;
        }

        ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
        Expression orderByProperty = Expression.Property(parameterExpression, propertyName);
        LambdaExpression lambda = Expression.Lambda(orderByProperty, parameterExpression);
        MethodInfo genericMethod = OrderByDescendingMethod.MakeGenericMethod(typeof(T), orderByProperty.Type);
        object ret = genericMethod.Invoke(null, new object[] { source, lambda });
        return (IRequestable<T>)ret;
    }
}