using Tenge.Domain.Commons;

namespace Tenge.Domain.Entities;

public class Collection : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long PictureId { get; set; }
    public Asset Picture { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
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
