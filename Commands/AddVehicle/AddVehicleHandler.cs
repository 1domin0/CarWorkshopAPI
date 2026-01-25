using AutoMapper;
using CarWorkshopAPI.Data;
using CarWorkshopAPI.Models;
using MediatR;

namespace CarWorkshopAPI.Commands.AddVehicle;

public class AddVehicleHandler(CarWorkshopDbContext _context, IMapper _mapper) : IRequestHandler<AddVehicleCommand, int>
{
    public async Task<int> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = _mapper.Map<Vehicle>(request.Dto);
        _context.Vehicles.Add(vehicle);
        
        await _context.SaveChangesAsync();
        return vehicle.Id;
    }
}