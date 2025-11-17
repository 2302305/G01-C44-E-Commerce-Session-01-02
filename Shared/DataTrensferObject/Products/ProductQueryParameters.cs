public class ProductQueryParameters
{
    private const int maxPageSize = 5;
    private const int DefaultPageSize = 5;
    public int? BrandId { get; set; }
    public int? TypeId { get; set; }
    public string? Search { get; set; }
    public ProductSorting Sort { get; set; }
    private int pageSize = DefaultPageSize;
    public int PageSize
    {
        get => pageSize; set => pageSize = value > maxPageSize ? maxPageSize
            : value < DefaultPageSize ? DefaultPageSize : value;
    }
    public int PAgeIndex { get; set; } = 1;
}


public enum ProductSorting
{
    NameAsc = 1,
    NameDesc = 2,
    PriceAsc = 3,
    PriceDesc = 4,



}