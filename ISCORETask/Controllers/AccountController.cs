using ISCORETask.DTOs;
using ISCORETask.DTOs.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace ISCORETask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            if (await _accountService.UserExists(registerDto.Username))
                _userManager.


        }
        //{
        //    if (await _accountService.UserExists(registerDto.Username))
        //    {
        //        return BadRequest("Username is taken");
        //    }

        //    var user = await _accountService.Register(registerDto);
        //    if (user == null)
        //    {
        //        return BadRequest("Failed to register");
        //    }

        //    var token = _tokenService.CreateToken(user);
        //    return Ok();
        //}

    }
}
