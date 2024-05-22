using Microsoft.AspNetCore.Mvc;
using Tenge.Service.Configurations;
using Tenge.WebApi.ApiServices.Users;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Models.Responses;
using Tenge.WebApi.Models.Users;

namespace Tenge.WebApi.Controllers;

public class UsersController(IUserApiService service) : BaseController
{
    //[HttpPost]
    //public async ValueTask<IActionResult> PostAdminAsync(UserCreateModel createModel)
    //{
    //    return Ok(new Response
    //    {
    //        StatusCode = 200,
    //        Message = "Ok",
    //        Data = await service.PostAdminAsync(createModel)
    //    });
    //}

    [HttpPost]
    public async ValueTask<IActionResult> PostNonAdminAsync(UserCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await service.PostAdminAsync(createModel)
        });
    }

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
}
