﻿using BudgeterDB;
using CoreServices;
using CoreServices.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BudgeterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                var result = await _userService.Signup(user);
                return Created("", result);
            }
            catch (UsernameAlreadyExistsException ex)
            {
                return StatusCode(409, ex.Message);                
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(User user)
        {
            try
            {
                var result = await _userService.SignIn(user);
                return Ok(result);
            }
            catch (InvalidSignInException ex)
            {
                return StatusCode(401, ex.Message);
            }

        }
    }
}
