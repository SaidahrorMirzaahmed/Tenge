using Microsoft.AspNetCore.Mvc;

namespace Tenge.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
}
