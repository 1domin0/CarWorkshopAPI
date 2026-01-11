using System.ComponentModel.DataAnnotations;

namespace CarWorkshopAPI.Dtos;

public class RegisterDto
{
    [Required] [StringLength(32, MinimumLength = 4)]
    public string Username { get; set; } = string.Empty;
    [Required] [StringLength(32, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
}