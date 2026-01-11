using CarWorkshopAPI.Dtos;

namespace CarWorkshopAPI.Services.Interfaces;

public interface IAuthService
{
    Task<string?> LoginAsync(LoginDto dto);
    Task RegisterAsync(RegisterDto dto);
}