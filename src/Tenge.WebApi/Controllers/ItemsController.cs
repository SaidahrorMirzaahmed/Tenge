using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tenge.Domain.Enums;
using Tenge.Service.Configurations;
using Tenge.WebApi.ApiServices.Items;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Models.Assets;
using Tenge.WebApi.Models.Items;
using Tenge.WebApi.Models.Responses;

namespace Tenge.WebApi.Controllers;

[CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.NonAdmin))]
public class ItemsController(IItemApiService service) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(ItemCreateModel createModel)
    {
        var isAdmin = new CustomAuthorize().IsUserAdmin(HttpContext.User);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.PostAsync(createModel, isAdmin)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, ItemUpdateModel updateModel)
    {
        var isAdmin = new CustomAuthorize().IsUserAdmin(HttpContext.User);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.PutAsync(id, updateModel, isAdmin)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var isAdmin = new CustomAuthorize().IsUserAdmin(HttpContext.User);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.DeleteAsync(id, isAdmin)
        });
    }

    [AllowAnonymous]
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.GetAsync(id)
        });
    }

    [AllowAnonymous]
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync(
        [FromQuery] PaginationParams @params,
        [FromQuery] Filter filter,
        [FromQuery] string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.GetAllAsync(@params, filter, search)
        });
    }

    [AllowAnonymous]
    [HttpGet("{id:long}/collection-id")]
    public async ValueTask<IActionResult> GetByColletionIdAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.GetItemsByCollectionId(id)
        });
    }

    [HttpPost("{id:long}/files/upload")]
    public async Task<IActionResult> PictureUploadAsync(long id, AssetCreateModel asset)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.UploadPictureAsync(id, asset)
        });
    }

    [HttpDelete("{id:long}/files/delete")]
    public async Task<IActionResult> PictureDeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await service.DeletePictureAsync(id)
        });
    }
}
