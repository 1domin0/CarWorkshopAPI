using System.ComponentModel.DataAnnotations;

namespace CarWorkshopAPI.Models;

public class Vehicle
{
    public int Id { get; set; }
    [MaxLength(32)]
    public string Brand { get; set; } = String.Empty;
    [MaxLength(32)]
    public string Model { get; set; } = String.Empty;
    public int Year { get; set; }
    
    public TechnicalPassport TechnicalPassport { get; set; }
    public List<MaintenanceRecord> MaintenanceRecords { get; set; }
}