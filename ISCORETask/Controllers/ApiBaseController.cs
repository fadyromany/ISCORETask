using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISCORETask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        public string? UserId { get; set; }
    }
}
