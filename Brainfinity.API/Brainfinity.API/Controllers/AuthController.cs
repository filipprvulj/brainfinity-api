using AutoMapper;
using Brainfinity.Domain.Dtos;
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
        private readonly IMapper mapper;
        private readonly IAuthService authService;

        public AuthController(IMapper mapper, IAuthService authService)
        {
            this.mapper = mapper;
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterTeamModel registerUser)
        {
            var team = mapper.Map<UserDto>(registerUser);

            return Ok(await authService.CreateTeamAsync(team, registerUser.Password));
        }
    }
}