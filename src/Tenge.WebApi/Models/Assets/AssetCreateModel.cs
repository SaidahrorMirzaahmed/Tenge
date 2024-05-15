﻿using Tenge.Service.Configurations;

namespace Tenge.WebApi.Models.Assets;

public class AssetCreateModel
{
    public IFormFile File { get; set; }
    public FileType FileType { get; set; }
}
