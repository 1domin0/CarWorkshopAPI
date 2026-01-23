using CarWorkshopAPI.Data;
using MediatR;

namespace CarWorkshopAPI.Commands.DeleteVehicle;

public class DeleteVehicleHandler(CarWorkshopDbContext _context) : IRequestHandler<DeleteVehicleCommand>
{
    public async Task Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _context.Vehicles.FindAsync(request.Id);
        if (vehicle == null) throw new KeyNotFoundException("Vehicle not found");
        
        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();
    }
}