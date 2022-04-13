using Core.Entities.Configurations;
using Core.Interfaces;
using Infrastructure.Helpers.Security;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        
        public UserController(IUserRepository userRepository, IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm]string login, [FromForm]string CodEmpresa)
        {
            var users = await _userRepository.GetUser(login, CodEmpresa);

            var token = "";
            if (users != null)
            {
                var key = _configuration["jwt:key"];
                token = TokenGenerator.getToken(key, login);
            }
            return Ok(new { login = users, token = token });
        }

        [Authorize]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }
    }
}
