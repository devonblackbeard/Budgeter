using BudgeterDB;
using CoreServices;
using CoreServices.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgeterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(User user)
        {
            try
            {
                var result = _userService.Signup(user);
                return Created("", result);

            }
            catch (UsernameAlreadyExists ex)
            {
                return StatusCode(409, ex.Message);                
            }

        }

    }
}
