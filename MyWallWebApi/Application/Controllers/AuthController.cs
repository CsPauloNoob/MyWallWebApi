using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MyWallWebApi.Domains.DTOs;
using MyWallWebApi.Domains.Models;
using MyWallWebApi.Domains.Services;
using MyWallWebApi.Insfrastructure.Data.Repositories;
using MyWallWebApi.Models;

namespace MyWallWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp([FromBody] SignUpDTO signUpDTO)
        {
            bool result = await _authService.SignUp(signUpDTO);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<ActionResult> SignIn([FromBody]SignInDTO signInDTO)
        {
            var ssoDTO = await _authService.SignIn(signInDTO);

            return Ok(ssoDTO);
        }



        [HttpGet("get-current-user")]
        public async Task<ActionResult> GetPost()
        {
            try
            {
                ApplicationUser user = await _authService.GetCurrentUser();
                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}