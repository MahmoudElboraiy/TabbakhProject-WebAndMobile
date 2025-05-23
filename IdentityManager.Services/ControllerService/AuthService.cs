﻿using DataAcess.Repos.IRepos;
using IdentityManager.Services.ControllerService.IControllerService;
using Models.DTOs.Auth;
using System.ComponentModel.DataAnnotations;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<object> LoginAsync(LoginRequestDTO loginRequestDTO)
    {
        return await _userRepository.Login(loginRequestDTO);
    }

    public async Task<string> ForgotPasswordAsync(ForgotPasswordRequestDTO forgotPasswordRequestDTO)
    {
        return await _userRepository.ForgotPasswordAsync(forgotPasswordRequestDTO);
    }

    public async Task<string> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
    {
        return await _userRepository.ResetPasswordAsync(resetPasswordDTO);
    }

    public async Task<object> RegisterAsync(RegisterRequestDTO registerRequestDTO)
    {
        var emailExist = await _userRepository.FindByEmailAsync(registerRequestDTO.Email);
        if (emailExist != null)
        {
            throw new ValidationException("Email Already exists");
        }
        return await _userRepository.Register(registerRequestDTO);
    }
}