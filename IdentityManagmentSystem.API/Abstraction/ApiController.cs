using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManagmentSystem.API.Abstraction
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ApiController : ControllerBase
    {

    }
}
