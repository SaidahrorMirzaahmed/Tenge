using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tenge.Domain.Enums;
using Tenge.Service.Configurations;
using Tenge.WebApi.ApiServices.Users;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Models.Responses;
using Tenge.WebApi.Models.Users;

namespace Tenge.WebApi.Controllers;

public class UsersController(IUserApiService service) : BaseController
{
    [CustomAuthorize(nameof(UserRole.Admin))]
    [HttpPost("admin")]
    public async ValueTask<IActionResult> PostAdminAsync(UserCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.PostAdminAsync(createModel)
        });
    }

    [AllowAnonymous]
    [HttpPost]
    public async ValueTask<IActionResult> PostNonAdminAsync(UserCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.PostNonAdminAsync(createModel)
        });
    }

    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.NonAdmin))]
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, UserUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.PutAsync(id, updateModel)
        });
    }

    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.NonAdmin))]
    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.DeleteAsync(id)
        });
    }

    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.NonAdmin))]
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

    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.NonAdmin))]
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

    [CustomAuthorize(nameof(UserRole.Admin))]
    [HttpPatch]
    public async ValueTask<IActionResult> QuitAdmin()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.QuitAdminAsync()
        });
    }

}
