using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CarWorkshopAPI.Data;
using CarWorkshopAPI.Dtos;
using CarWorkshopAPI.Models;
using CarWorkshopAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CarWorkshopAPI.Services;

public class AuthService : IAuthService
{
    private readonly CarWorkshopDbContext _context;
    private readonly IPasswordHasher<User> _hasher;
    private readonly IConfiguration _configuration;
    public AuthService(CarWorkshopDbContext context, IPasswordHasher<User> hasher, IConfiguration configuration)
    {
        _context = context;
        _hasher = hasher;
        _configuration = configuration;
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _context.Users.AnyAsync(u => u.Username == dto.Username);
        
        if (existingUser)
            throw new InvalidOperationException("Username already exists");
        
        var user = new User
        {
            Username = dto.Username,
            Role = "User"
        };
        user.PasswordHash = _hasher.HashPassword(user, dto.Password);
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task<string?> LoginAsync(LoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
        if (user == null) return null;
        
        var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        
        return result is not PasswordVerificationResult.Success ? null : GenerateJwtToken(user);
    }
    
    public string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}