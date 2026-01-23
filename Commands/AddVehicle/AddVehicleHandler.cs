using AutoMapper;
using CarWorkshopAPI.Data;
using CarWorkshopAPI.Models;
using MediatR;

namespace CarWorkshopAPI.Commands.AddVehicle;

public class AddVehicleHandler : IRequestHandler<AddVehicleCommand, int>
{
    private readonly CarWorkshopDbContext _context;
    private readonly IMapper _mapper;

    public AddVehicleHandler(CarWorkshopDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = _mapper.Map<Vehicle>(request.Dto);
        _context.Vehicles.Add(vehicle);
        
        await _context.SaveChangesAsync();
        return vehicle.Id;
    }
}