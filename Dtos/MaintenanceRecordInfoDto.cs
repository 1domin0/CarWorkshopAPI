using System.ComponentModel.DataAnnotations;

namespace CarWorkshopAPI.Dtos;

public class MaintenanceRecordInfoDto
{
    [StringLength(400, MinimumLength = 10)]
    public string Description { get; set; } = string.Empty;
    
    [Required][Range(0,99999)]
    public int Cost { get; set; }
}