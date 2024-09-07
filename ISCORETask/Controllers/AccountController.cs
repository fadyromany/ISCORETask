using ISCORETask.DTOs;
using ISCORETask.DTOs.Request;
using ISCORETask.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace ISCORETask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiBaseController
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        public AccountController(IConfiguration configuration, IAccountService accountService)
        {
            _configuration = configuration;
            _accountService = accountService;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var (error, reponse) = await _accountService.Register(registerDto);
            return error != null ? BadRequest(error) : Ok(reponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var (error, reponse) = await _accountService.Login(loginDto);
            return error != null ? BadRequest(error) : Ok(reponse);
        }

    }
}
