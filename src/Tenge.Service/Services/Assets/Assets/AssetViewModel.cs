using Microsoft.AspNetCore.Http;
using Tenge.Service.Configurations;

namespace Tenge.WebApi.Models.Assets;

public class AssetViewModel
{
    public IFormFile File { get; set; }
    public FileType FileType { get; set; }
}
