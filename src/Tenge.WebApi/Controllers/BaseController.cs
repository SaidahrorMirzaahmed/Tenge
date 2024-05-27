using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Tenge.Domain.Enums;

namespace Tenge.WebApi.Controllers;

[EnableCors("AllowSpecificOrigin")]
[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
}
