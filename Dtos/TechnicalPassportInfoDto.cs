using System.ComponentModel.DataAnnotations;

namespace CarWorkshopAPI.Dtos;

public class TechnicalPassportInfoDto
{
    [StringLength(10, MinimumLength = 3)]
    public string RegistrationNumber { get; set; } = string.Empty;
    
    [Required] [StringLength(30, MinimumLength = 6)]
    public string OwnerName { get; set; } = string.Empty;
}