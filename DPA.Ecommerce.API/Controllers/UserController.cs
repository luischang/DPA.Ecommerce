using DPA.Ecommerce.DOMAIN.Core.DTOs;
using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DPA.Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] UserSignupDTO dto)
        {
            var id = await _userService.SignupAsync(dto);
            return CreatedAtAction(nameof(Signup), new { id }, id);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] UserSigninDTO dto)
        {
            var result = await _userService.SigninAsync(dto);
            if (result == null) return Unauthorized();
            return Ok(result);
        }
    }
}
