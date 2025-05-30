﻿using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Auth;
using IdentityManager.Services.ControllerService.IControllerService;
using System.Threading.Tasks;
using DataAcess.Services;
using Microsoft.AspNetCore.Identity;
using Models.DTOs.User;

namespace IdentityManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthUserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var result = await _authService.LoginAsync(loginRequestDTO);
            var loginResponse = result as LoginResponseDTO;

            if (loginResponse == null || string.IsNullOrEmpty(loginResponse.Token) || loginResponse.User == null)
            {
                return Ok(new
                {
                    message = "Invalid email or password",
                    token = "",
                    user = (UserDTO?)null
                });
            }

            return Ok(new
            {
                message = "Welcome",
                token = loginResponse.Token,
                user = loginResponse.User
            });
        }

        // Register
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var result = await _authService.RegisterAsync(registerRequestDTO);
            return Ok(result);
        }

        // Forgot-Password
        [HttpPost("RequestPasswordReset")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDTO forgotPasswordRequestDTO)
        {
            var result = await _authService.ForgotPasswordAsync(forgotPasswordRequestDTO);
            if (result == "User not found.")
            {
                return NotFound(new { message = "User not found." });
            }
            return Ok(new { token = result });
        }

        // Reset-Password
        [HttpPost("ResetUserPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var result = await _authService.ResetPasswordAsync(resetPasswordDTO);
            return Ok(new { message = result });
        }
    }
}