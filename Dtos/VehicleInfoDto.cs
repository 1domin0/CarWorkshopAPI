using System.ComponentModel.DataAnnotations;

namespace CarWorkshopAPI.Dtos;

public class VehicleInfoDto
{
    [Required][StringLength(50, MinimumLength = 2)]
    public string Brand { get; set; } = string.Empty;
    
    [Required][StringLength(50, MinimumLength = 2)]
    public string Model { get; set; } = string.Empty;
    
    [Required][Range(1800, 2026)]
    public int Year { get; set; }
}