using AutoMapper;
using CarWorkshopAPI.Data;
using CarWorkshopAPI.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshopAPI.Queries.GetVehicles;

public class GetVehiclesHandler : IRequestHandler<GetVehiclesQuery, List<VehicleInfoDto>>
{
    private readonly CarWorkshopDbContext _context;
    private readonly IMapper _mapper;

    public GetVehiclesHandler(CarWorkshopDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<VehicleInfoDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _context.Vehicles.ToListAsync();
        
        var vehicleInfoDtos = _mapper.Map<List<VehicleInfoDto>>(vehicles);
        
        return vehicleInfoDtos;
    }
}