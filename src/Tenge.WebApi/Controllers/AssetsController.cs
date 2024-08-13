using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;
using Tenge.Service.Assets.Service;
using Tenge.WebApi.Models.Assets;
using Tenge.WebApi.Models.Responses;

namespace Tenge.WebApi.Controllers;

[EnableCors("AllowSpecificOrigin")]
[Route("api/[controller]")]
[ApiController]
public class AssetsController(IAssetService service) : ControllerBase
{
    [HttpPost]
    public async ValueTask<IActionResult> UploadPictureOnly([FromBody]AssetCreateModel model)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await service.UploadAsync(model)
        });
    }
}
