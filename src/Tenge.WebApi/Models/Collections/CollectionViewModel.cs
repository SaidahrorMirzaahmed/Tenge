using Tenge.Domain.Entities;
using Tenge.WebApi.Models.Assets;
using Tenge.WebApi.Models.Category;
using Tenge.WebApi.Models.Users;

namespace Tenge.WebApi.Models.Collections;

public class CollectionViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public AssetViewModel Picture { get; set; }
    public UserViewModel User { get; set; }
    public CategoryViewModel Category { get; set; }
    public string? CustomString1 { get; set; }
    public string? CustomString2 { get; set; }
    public string? CustomString3 { get; set; }
    public int? CustomInt1 { get; set; }
    public int? CustomInt2 { get; set; }
    public int? CustomInt3 { get; set; }
    public DateTime? CustomDate1 { get; set; }
    public DateTime? CustomDate2 { get; set; }
    public DateTime? CustomDate3 { get; set; }
}
