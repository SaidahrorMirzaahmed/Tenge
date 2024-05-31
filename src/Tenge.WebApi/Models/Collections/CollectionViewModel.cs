using Tenge.Domain.Entities;
using Tenge.Service.Services.Assets.Assets;
using Tenge.WebApi.Models.Assets;
using Tenge.WebApi.Models.Category;
using Tenge.WebApi.Models.Users;

namespace Tenge.WebApi.Models.Collections;

public class CollectionViewModel
{
    public long Id { get; set; }    
    public string Name { get; set; }
    public string Description { get; set; }
    public AssetViewModel Picture { get; set; }
    public UserViewModel User { get; set; }
    public CategoryViewModel Category { get; set; }
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
