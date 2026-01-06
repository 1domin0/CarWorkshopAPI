namespace CarWorkshopAPI.Models;

public class MaintenanceRecord
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Cost { get; set; }
    public int VehicleId { get; set; }
    
    public Vehicle Vehicle { get; set; }
}