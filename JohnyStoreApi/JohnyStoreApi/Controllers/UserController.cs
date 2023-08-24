using JohnyStoreApi.Models.User;
using JohnyStoreApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JohnyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Вход в систему
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LogPassModel model)
        {
            string token = _userService.Login(model);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { token = token });
        }
        /// <summary>
        /// Регистрация в системе
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Route("Register")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Register([FromBody] LogPassModel model)
        {
            var token = _userService.AddUser(model);
            if(string.IsNullOrEmpty(token)) 
                return BadRequest();

            return Ok(new { token = token });
        }
        /// <summary>
        /// Изменение пароля
        /// </summary>
        /// <param name="edit"></param>
        /// <returns></returns>
        [Route("EditPassword")]
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult EditPassword([FromBody] EditPasswordModel edit)
        {
            var token = _userService.EditPassword(edit);
            if (string.IsNullOrEmpty(token))
                return BadRequest();

            return Ok(new { token = token });
        }
    }
}
