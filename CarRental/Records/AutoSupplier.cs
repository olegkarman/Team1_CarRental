namespace CarRental.Records;
public record AutoSupplier
{
    public string SupplierId { get; init; }
    public string CompanyName { get; init; }
    public string ContactName { get; init; }
    public string ContactPhone { get; init; }
    public string Address { get; init; }
}
