using AutoMapper;
using CarWorkshopAPI.Data;
using CarWorkshopAPI.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshopAPI.Queries.GetVehicles;

public class GetVehiclesHandler(CarWorkshopDbContext _context, IMapper _mapper) : IRequestHandler<GetVehiclesQuery, List<VehicleInfoDto>>
{
    public async Task<List<VehicleInfoDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _context.Vehicles.ToListAsync();
        
        var vehicleInfoDtos = _mapper.Map<List<VehicleInfoDto>>(vehicles);
        
        return vehicleInfoDtos;
    }
}