using AutoMapper;
using CarWorkshopAPI.Data;
using CarWorkshopAPI.Models;
using MediatR;

namespace CarWorkshopAPI.Commands.UpdateVehicle;

public class UpdateVehicleHandler(CarWorkshopDbContext _context, IMapper _mapper) : IRequestHandler<UpdateVehicleCommand>
{
    public async Task Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _context.Vehicles.FindAsync(request.Id);
        
        if (vehicle == null) throw new KeyNotFoundException("Vehicle not found");
        
        _mapper.Map(request.Dto, vehicle);

        await _context.SaveChangesAsync();
    }
}