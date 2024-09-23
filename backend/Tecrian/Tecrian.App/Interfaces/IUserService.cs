using Microsoft.Extensions.Configuration;
using Tecrian.Domain.Entities;
using Tecrian.Shared.Dtos;

namespace Tecrian.App.Services;

public interface IUserService
{
    Task<TokenResponse> Login(LoginDto dto);
    Task<TokenResponse> SignUp(CreateUserDto dto);
    Task<User?> GetUser(int id);
    Task<List<User>> GetUsers();
    Task<bool> UpdateUser(UpdateUserDto dto);
    Task<bool> DeleteUser(int id);
    Task ConfirmEmail(int id, string token, IConfiguration config);

}
