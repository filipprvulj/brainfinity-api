using Brainfinity.Domain.Models;
using Brainfinity.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainfinity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromForm] RegisterTeamModel registerUser)
        {
            return Ok(await authService.CreateTeamAsync(registerUser));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserModel loginUser)
        {
            return Ok(await authService.LoginUserAsync(loginUser));
        }
    }
}