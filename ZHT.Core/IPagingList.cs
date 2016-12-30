
using System.Collections.Generic;

namespace ZHT.Core
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    public interface IPagingList<T> : IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
