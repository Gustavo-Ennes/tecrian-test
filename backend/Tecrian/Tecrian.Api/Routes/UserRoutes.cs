using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Tecrian.Api.Validators.User;
using Tecrian.App.Services;
using Tecrian.Shared.Dtos;
using Tecrian.Shared.Utils;

namespace Tecrian.Api.Routes;

[ApiController]
[Route("api/user")]
public class UserControllers(
    IUserService userService,
    IMapper mapper,
    IConfiguration config,
    ILogger<UserControllers> logger
) : ControllerBase
{
    private readonly IUserService _userService = userService;
    private readonly IMapper _mapper = mapper;
    private readonly IConfiguration _config = config;
    private readonly ILogger<UserControllers> _logger = logger;


    [HttpGet]
    public async Task<ActionResult<List<UpdateUserDto>>> GetUsers()
    {
        var users = await _userService.GetUsers();
        var mappedUsers = _mapper.Map<List<UpdateUserDto>>(users);
        return Ok(mappedUsers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UpdateUserDto?>> GetUser(int id)
    {
        var user = await _userService.GetUser(id);
        if (user == null)
            return NotFound();

        return Ok(_mapper.Map<UpdateUserDto>(user));
    }

    [HttpGet("confirmEmail/{id}/{token}")]
    public async Task<ActionResult<bool>> ConfirmEmail(int id, string token)
    {
        await _userService.ConfirmEmail(id, token, _config);
        return Ok();

    }

    [HttpPost("signup")]
    public async Task<ActionResult<TokenResponse>> SignUp(CreateUserDto dto)
    {
        var validator = new CreateUserValidator();
        var validationResult = validator.Validate(dto);

        if (!validationResult.IsValid)
        {
            Log.Error($"Sign up error: {validationResult.Errors.First().ErrorMessage}. Total Errors: {validationResult.Errors.Count}");
            return BadRequest(new { Title = "Sign up validation error", validationResult.Errors });
        }
        var tokenResponse = await _userService.SignUp(dto);
        return Ok(tokenResponse);
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenResponse>> Login(LoginDto dto)
    {
        var validator = new CreateLoginValidator();
        var validationResults = validator.Validate(dto);

        if (!validationResults.IsValid)
            return BadRequest(new { Title = "Login validation error", validationResults.Errors });

        var tokenResponse = await _userService.Login(dto);
        return Ok(tokenResponse);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserDto dto)
    {
        var validator = new UpdateUserValidator();
        var validationResults = validator.Validate(dto);

        if (!validationResults.IsValid)
            return BadRequest(new { Title = "Update user validation error", validationResults.Errors });

        await _userService.UpdateUser(dto);
        return Ok(true);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUser(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
