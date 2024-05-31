using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tenge.Domain.Enums;
using Tenge.Service.Configurations;
using Tenge.WebApi.ApiServices.Collections;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Models.Assets;
using Tenge.WebApi.Models.Category;
using Tenge.WebApi.Models.Collections;
using Tenge.WebApi.Models.Responses;

namespace Tenge.WebApi.Controllers;

[CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.NonAdmin))]
public class CollectionsController(ICollectionApiService service) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(CollectionCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, CollectionUpdateModel updateModel)
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
    [HttpGet("{id:long}/user-id")]
    public async ValueTask<IActionResult> GetAllByUserIdAsync(
        long id,
        [FromQuery] PaginationParams @params,
        [FromQuery] Filter filter,
        [FromQuery] string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.GetbyUserIdAsync(id,@params, filter, search)
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
