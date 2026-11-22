using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Data;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Services;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{

    // api/users
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authservice;

        public AuthController(IAuthService authservice)
        {
            _authservice = authservice;
        }



        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var authResponse = _authservice.Login(loginDto);

            if (authResponse is null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }

    }
}
