using Core.Entities;
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

        //[Authorize]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(new { users = users });
        }

        [HttpPost("userForm")]
        public async Task<IActionResult> GetUserForm([FromBody]User user)
        {
            var users = await _userRepository.GetUserForm(user.CodUsuario);
            return Ok(new { users = users });
        }

        [HttpPost("insertUser")]
        public async Task<IActionResult> InsertUser([FromBody] User user)
        {
            try
            {
                var users = await _userRepository.InsertUser(user.Login, user.Nombres, user.Apellidos, user.CodEmpresa, user.TipoUsuarioMa, user.Clave, user.CodUsuarioActualizacion);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                var users = await _userRepository.UpdateUser(user.CodUsuario, user.Login, user.Nombres, user.Apellidos, user.CodEmpresa, user.TipoUsuarioMa, user.CodUsuarioActualizacion);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost("deleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] User user)
        {
            try
            {
                var users = await _userRepository.DeleteUser(user.CodUsuario, user.CodUsuarioActualizacion);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost("updatePswdUser")]
        public async Task<IActionResult> UpdatePswdUser([FromBody] User user)
        {
            try
            {
                var users = await _userRepository.UpdatePswdUser(user.CodUsuario, user.Clave);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
