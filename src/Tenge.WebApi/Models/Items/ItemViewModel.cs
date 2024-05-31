using Tenge.Service.Services.Assets.Assets;
using Tenge.WebApi.Models.Assets;
using Tenge.WebApi.Models.Collections;

namespace Tenge.WebApi.Models.Items;

public class ItemViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public AssetViewModel Picture { get; set; }
    public CollectionViewModel CollectionViewModel { get; set; }
    public AssetViewModel AssetViewModel { get; set; }
    public string? CustomString1Value { get; set; }
    public string? CustomString2Value { get; set; }
    public string? CustomString3Value { get; set; }
    public int? CustomInt1Value { get; set; }
    public int? CustomInt2Value { get; set; }
    public int? CustomInt3Value { get; set; }
    public DateTime? CustomDate1Value { get; set; }
    public DateTime? CustomDate2Value { get; set; }
    public DateTime? CustomDate3Value { get; set; }
}
