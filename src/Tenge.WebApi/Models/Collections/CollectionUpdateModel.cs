namespace Tenge.WebApi.Models.Collections;

public class CollectionUpdateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public string? CustomString1 { get; set; }
    public string? CustomString2 { get; set; }
    public string? CustomString3 { get; set; }
    public string? CustomInt1 { get; set; }
    public string? CustomInt2 { get; set; }
    public string? CustomInt3 { get; set; }
    public string? CustomDate1 { get; set; }
    public string? CustomDate2 { get; set; }
    public string? CustomDate3 { get; set; }
}
