﻿namespace Cledev.Core.Utilities.Queries;

public class RequestOptions
{
    private const int DefaultPageSize = 10;
    public string? Search { get; set; }
    public string? OrderByField { get; set; }

    public OrderByDirectionType? OrderByDirection { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }

    public int Skip => (CurrentPage - 1) * PageSize;
    public bool SearchIsDefined() => !string.IsNullOrWhiteSpace(Search);
    public bool OrderByFieldIsDefined() => !string.IsNullOrWhiteSpace(OrderByField) && OrderByDirection != null;

    public RequestOptions(int? currentPage = 1, string? search = null, string? orderByField = null, string? orderByDirection = null, int? pageSize = null)
    {
        CurrentPage = SetCurrentPage(currentPage);
        Search = search;
        OrderByField = orderByField;
        PageSize = pageSize ?? DefaultPageSize;

        if (!string.IsNullOrWhiteSpace(orderByDirection) && Enum.TryParse(orderByDirection, out OrderByDirectionType orderByDirectionType))
        {
            OrderByDirection = orderByDirectionType;
        }
    }

    private static int SetCurrentPage(int? currentPage) => currentPage is null or < 1 ? 1 : currentPage.Value;
}