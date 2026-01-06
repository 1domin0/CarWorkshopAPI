namespace CarWorkshopAPI.Models;

public class TechnicalPassport
{
    public int Id { get; set; }
    
    public string RegistrationNumber { get; set; } = String.Empty;
    public string OwnerName { get; set; } = String.Empty;
    
    public int VehicleId { get; set; }
    
    public Vehicle Vehicle { get; set; }
}