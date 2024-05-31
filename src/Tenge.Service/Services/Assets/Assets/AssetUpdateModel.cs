using Microsoft.AspNetCore.Http;
using Tenge.Service.Configurations;

namespace Tenge.WebApi.Models.Assets;

public class AssetUpdateModel
{
    public IFormFile File { get; set; }
    public FileType FileType { get; set; }
}
