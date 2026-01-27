using AutoMapper;
using CarWorkshopAPI.Data;
using CarWorkshopAPI.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshopAPI.Queries.GetVehiclesByBrand;

public class GetVehiclesByBrandHandler(CarWorkshopDbContext _context, IMapper _mapper) : IRequestHandler<GetVehiclesByBrandQuery, List<VehicleInfoDto>>
{
    public async Task<List<VehicleInfoDto>> Handle(GetVehiclesByBrandQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _context.Vehicles
            .Where(v => v.Brand.ToLower() == request.Brand.ToLower())
            .ToListAsync();
        
        return _mapper.Map<List<VehicleInfoDto>>(vehicles);
    }
}