using AutoMapper;
using CarWorkshopAPI.Data;
using CarWorkshopAPI.Dtos;
using MediatR;
namespace CarWorkshopAPI.Queries.GetVehicle;

public class GetVehicleByIdHandler(CarWorkshopDbContext _context, IMapper _mapper) : IRequestHandler<GetVehicleByIdQuery, VehicleInfoDto>
{
    public async Task<VehicleInfoDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _context.Vehicles.FindAsync(request.Id);
        
        if (vehicle == null) throw new KeyNotFoundException("ID not found");
            
        var vehicleInfoDto = _mapper.Map<VehicleInfoDto>(vehicle);
        return vehicleInfoDto;
    }
}