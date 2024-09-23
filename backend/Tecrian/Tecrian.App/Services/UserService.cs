using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Tecrian.Domain.Entities;
using Tecrian.Infra.Database.Repository;
using Tecrian.Shared.Dtos;
using Serilog;
using Tecrian.Shared.Utils.Hash;
using Tecrian.Infra.Email;
using RestSharp;
using Tecrian.Shared.Utils;

namespace Tecrian.App.Services;

public class UserService(
    IRepository<User> userRepository,
    IMapper mapper,
    IConfiguration configuration,
    ILogger<UserService> logger,
    IEmailSender emailSender
) : IUserService
{
    private readonly IRepository<User> _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IConfiguration _configuration = configuration;
    private readonly ILogger<UserService> _logger = logger;
    private readonly IEmailSender _emailSender = emailSender;

    public async Task<TokenResponse> Login(LoginDto dto)
    {
        try
        {
            User? user = await _userRepository.GetByEmail(dto.Email)
                ?? throw new Exception("User not found.");

            if (!HashUtils.VerifyPassword(dto.Password, user.Password))
                throw new Exception("Password don't match.");

            if(!user.IsEmailVerified)
                throw new Exception("User should verify email first.");

            string token = JwtUtils.GenerateJwtToken(
                user.Id,
                user.Email,
                user.IsEmailVerified,
                _logger,
                _configuration
            );

            return new TokenResponse()
            {
                Token = token
            };
        }
        catch (Exception err)
        {
            _logger.LogError("Login error: {err}", err.Message);
            throw;
        }
    }

    public async Task<TokenResponse> SignUp(CreateUserDto dto)
    {
        try
        {
            User user = _mapper.Map<User>(dto);
            User addedUser = await _userRepository.AddAsync(user);
            string token = JwtUtils.GenerateJwtToken(
                addedUser.Id,
                addedUser.Email,
                addedUser.IsEmailVerified,
                _logger,
                _configuration
            );

            RestResponse emailResponse = _emailSender.SendEmail(new EmailArgs()
            {
                To = [new() { Email = dto.Email ?? "" }],
                From = new() { Email = "no-reply@ennes.dev", Name = "Tecrian confirmation" },
                Category = "Confirmation",
                Subject = "Confirm your account",
                Html = EmailTemplate.Get(user.Id, token),
            });

            return new TokenResponse()
            {
                Token = token
            };
        }
        catch (Exception err)
        {
            Log.Error("SignUp error: {err}", err.Message);
            throw;
        }
    }

    public async Task<User?> GetUser(int id)
    {
        try
        {
            User? user = await _userRepository.GetByIdAsync(id);
            return user;
        }
        catch (Exception err)
        {
            _logger.LogError("GetUser error: {err}", err.Message);
            throw;
        }
    }


    public async Task<List<User>> GetUsers()
    {
        try
        {
            List<User> users = await _userRepository.GetAllAsync();
            return users;
        }
        catch (Exception err)
        {
            _logger.LogError("GetUsers error: {err}", err.Message);
            throw;
        }
    }

    public async Task<bool> UpdateUser(UpdateUserDto dto)
    {
        try
        {
            User? existingUser = await _userRepository.GetByIdAsync(dto.Id)
                ?? throw new Exception("No user found.");

            if (dto.Password != null)
                existingUser.Password = HashUtils.HashPassword(dto.Password);
            if (dto.Email != null)
                existingUser.Email = dto.Email;
            if (dto.Name != null)
                existingUser.Name = dto.Name;

            await _userRepository.UpdateAsync(existingUser);
            return true;

        }
        catch (Exception err)
        {
            _logger.LogError("UpdateUser error: {err}", err.Message);
            throw;
        }
    }

    public async Task<bool> DeleteUser(int id)
    {
        try
        {
            await _userRepository.DeleteAsync(id);
            return true;
        }
        catch (Exception err)
        {
            _logger.LogError("DeleteUser error: {err}", err.Message);
            throw;
        }
    }

    public async Task ConfirmEmail(int id, string token, IConfiguration config)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new Exception("Token is missing.");

            // Decodificar e validar o token JWT
            var userId = JwtUtils.GetUserIdFromToken(token, _logger, config)
                ?? throw new Exception("User id not found in token.");

            var user = await GetUser(userId)
                ?? throw new Exception("User not found in database.");

            user.IsEmailVerified = true;
            await _userRepository.UpdateAsync(user);

        }
        catch (Exception err)
        {
            _logger.LogError("Email confirmation: {err}", err.Message);
            throw;
        }
    }
}
