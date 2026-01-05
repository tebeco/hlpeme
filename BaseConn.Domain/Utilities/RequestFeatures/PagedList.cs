namespace BaseConn.Domain.Utilities.RequestFeatures;

 /// <summary>
/// Represents a paginated list of items along with associated metadata.
/// </summary>
/// <typeparam name="T">The type of items in the list.</typeparam>
public class PagedList<T> : List<T>
{
    /// <summary>
    /// Gets or sets the metadata information for pagination.
    /// </summary>
    public MetaData MetaData { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
    /// </summary>
    /// <param name="items">The list of items on the current page.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="count">The total count of items.</param>
    public PagedList(List<T> items, int pageNumber, int pageSize, int count)
    {
        MetaData = new MetaData
        {
            TotalCount = count,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };
        AddRange(items);
    }

    /// <summary>
    /// Converts a list of items to a paginated list with associated metadata.
    /// </summary>
    /// <param name="items">The list of items on the current page.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="count">The total count of items.</param>
    /// <returns>A paginated list of items.</returns>
    public static PagedList<T> ToPagedList(List<T> items, int pageNumber, int pageSize, int count)
    {
        return new PagedList<T>(items, pageNumber, pageSize, count);
    }
}
